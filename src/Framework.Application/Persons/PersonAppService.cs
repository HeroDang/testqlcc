using Abp.Application.Services.Dto;
using Abp.Domain.Repositories;
using AutoMapper;
using Framework.PhoneBook;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abp.Extensions;
using Abp.Collections.Extensions;
using Framework.PhoneBook.Dto;
using Abp.Authorization;
using Framework.Authorization;
using Microsoft.EntityFrameworkCore;

using System.Linq.Dynamic.Core;
using Abp.Linq.Extensions;
using Microsoft.EntityFrameworkCore;
using Framework.Persons.Exporting;
using Framework.Dto;

namespace Framework.Persons
{
    [AbpAuthorize(AppPermissions.Pages_Tenant_PhoneBook)]
    public class PersonAppService : FrameworkAppServiceBase, IPersonAppService
    {
        private readonly IRepository<Person> _personRepository;
        private readonly IRepository<Phone, long> _phoneRepository;
        private readonly IPeoplesExcelExporter_PhoneBook _personExcelExporter;


        public PersonAppService(IRepository<Person> personRepository, IRepository<Phone,long> phoneRepository, IPeoplesExcelExporter_PhoneBook personExcelExporter)
        {
            _personRepository = personRepository;
            _phoneRepository = phoneRepository;
            _personExcelExporter = personExcelExporter;
        }

        public ListResultDto<PersonListDto> GetPeople(GetPeopleInput input)
        {
            var persons = _personRepository
                .GetAll()
                .Include(p => p.Phones)
                .WhereIf(
                    !input.Filter.IsNullOrEmpty(),
                    p => p.Name.Contains(input.Filter) ||
                            p.Surname.Contains(input.Filter) ||
                            p.EmailAddress.Contains(input.Filter)
                )
                .OrderBy(p => p.Name)
                .ThenBy(p => p.Surname)
                .ToList();

            return new ListResultDto<PersonListDto>(ObjectMapper.Map<List<PersonListDto>>(persons));
        }

        [AbpAuthorize(AppPermissions.Pages_Tenant_PhoneBook_CreatePerson)]
        public async Task CreatePerson(CreatePersonInput input)
        {
            var person = ObjectMapper.Map<Person>(input);
            await _personRepository.InsertAsync(person);
        }

        [AbpAuthorize(AppPermissions.Pages_Tenant_PhoneBook_DeletePerson)]
        public async Task DeletePerson(EntityDto input)
        {
            await _personRepository.DeleteAsync(input.Id);
        }

        [AbpAuthorize(AppPermissions.Pages_Tenant_PhoneBook_EditPerson)]
        public async Task DeletePhone(EntityDto<long> input)
        {
            await _phoneRepository.DeleteAsync(input.Id);
        }

        [AbpAuthorize(AppPermissions.Pages_Tenant_PhoneBook_EditPerson)]
        public async Task<PhoneInPersonListDto> AddPhone(AddPhoneInput input)
        {
            var person = _personRepository.Get(input.PersonId);
            await _personRepository.EnsureCollectionLoadedAsync(person, p => p.Phones);

            var phone = ObjectMapper.Map<Phone>(input);
            person.Phones.Add(phone);

            //Get auto increment Id of the new Phone by saving to database
            await CurrentUnitOfWork.SaveChangesAsync();

            return ObjectMapper.Map<PhoneInPersonListDto>(phone);
        }

        [AbpAuthorize(AppPermissions.Pages_Tenant_PhoneBook_EditPerson)]
        public async Task<GetPersonForEditOutput> GetPersonForEdit(GetPersonForEditInput input)
        {
            var person = await _personRepository.GetAsync(input.Id);
            return ObjectMapper.Map<GetPersonForEditOutput>(person);
        }

        [AbpAuthorize(AppPermissions.Pages_Tenant_PhoneBook_EditPerson)]
        public async Task EditPerson(EditPersonInput input)
        {
            var person = await _personRepository.GetAsync(input.Id);
            person.Name = input.Name;
            person.Surname = input.SurName;
            person.EmailAddress = input.EmailAddress;
            await _personRepository.UpdateAsync(person);
        }

        public async Task<PagedResultDto<GetPeopleForViewDto_PhoneBook>> GetAll(GetAllPeoplesInput_PhoneBook input)
        {

            var filteredPeoples = _personRepository.GetAll()
                        .WhereIf(!string.IsNullOrWhiteSpace(input.Filter), e => false || e.Name.Contains(input.Filter))
                        .WhereIf(!string.IsNullOrWhiteSpace(input.NameFilter), e => e.Name == input.NameFilter);

            var pagedAndFilteredPeoples = filteredPeoples
                .OrderBy(input.Sorting ?? "id asc")
                .PageBy(input);

            var peoples = from o in pagedAndFilteredPeoples
                          select new
                          {

                              o.Name,
                              o.Surname,
                              o.EmailAddress,
                              Id = o.Id
                          };

            var totalCount = await filteredPeoples.CountAsync();

            var dbList = await peoples.ToListAsync();
            var results = new List<GetPeopleForViewDto_PhoneBook>();

            foreach (var o in dbList)
            {
                var res = new GetPeopleForViewDto_PhoneBook()
                {
                    Person = new PersonDto
                    {

                        Name = o.Name,

                        Surname = o.Surname,
                        EmailAddress = o.EmailAddress,
                        Id = o.Id,
                    }
                };

                results.Add(res);
            }

            return new PagedResultDto<GetPeopleForViewDto_PhoneBook>(
                totalCount,
                results
            );

        }

        public async Task<GetPeopleForViewDto_PhoneBook> GetPeopleForView(int id)
        {
            var people = await _personRepository.GetAsync(id);

            var output = new GetPeopleForViewDto_PhoneBook { Person = ObjectMapper.Map<PersonDto>(people) };

            return output;
        }

        //[AbpAuthorize(AppPermissions.Pages_Peoples_Edit)]
        public async Task<GetPeopleForEditOutput_PhoneBook> GetPeopleForEdit(EntityDto input)
        {
            var people = await _personRepository.FirstOrDefaultAsync(input.Id);

            var output = new GetPeopleForEditOutput_PhoneBook { People = ObjectMapper.Map<CreateOrEditPeopleDto_PhoneBook>(people) };

            return output;
        }

        public async Task<FileDto> GetPeoplesToExcel(GetAllPeoplesForExcelInput_PhoneBook input)
        {

            var filteredPeoples = _personRepository.GetAll()
                        .WhereIf(!string.IsNullOrWhiteSpace(input.Filter), e => false || e.Name.Contains(input.Filter))
                        .WhereIf(!string.IsNullOrWhiteSpace(input.NameFilter), e => e.Name == input.NameFilter);

            var query = (from o in filteredPeoples
                         select new GetPeopleForViewDto_PhoneBook()
                         {
                             Person = new PersonDto
                             {
                                 Name = o.Name,
                                 Surname = o.Surname,
                                 EmailAddress = o.EmailAddress,
                                 Id = o.Id
                             }
                         });

            var peopleListDtos = await query.ToListAsync();

            return _personExcelExporter.ExportToFile(peopleListDtos);
        }
        /*
                public async Task CreateOrEdit(CreateOrEditPeopleDto_PhoneBook input)
                {
                    if (input.Id == null)
                    {
                        await Create(input);
                    }
                    else
                    {
                        await Update(input);
                    }
                }

                //[AbpAuthorize(AppPermissions.Pages_Peoples_Create)]
                protected virtual async Task Create(CreateOrEditPeopleDto_PhoneBook input)
                {
                    var people = ObjectMapper.Map<Person>(input);

                    *//*
                    if (AbpSession.TenantId != null)
                    {
                        people.TenantId = (int?)AbpSession.TenantId;
                    }
                    *//*

                    await _personRepository.InsertAsync(people);

                }

                //[AbpAuthorize(AppPermissions.Pages_Peoples_Edit)]
                protected virtual async Task Update(CreateOrEditPeopleDto_PhoneBook input)
                {
                    var people = await _personRepository.FirstOrDefaultAsync((int)input.Id);
                    ObjectMapper.Map(input, people);

                }

                //[AbpAuthorize(AppPermissions.Pages_Peoples_Delete)]
                public async Task Delete(EntityDto input)
                {
                    await _personRepository.DeleteAsync(input.Id);
                }*/

        /*public async Task<FileDto> GetPeoplesToExcel(GetAllPeoplesForExcelInput_PhoneBook input)
        {
            var filteredPeoples = _personRepository.GetAll()
                        .WhereIf(!string.IsNullOrWhiteSpace(input.Filter), e => false || e.Name.Contains(input.Filter))
                        .WhereIf(!string.IsNullOrWhiteSpace(input.NameFilter), e => e.Name == input.NameFilter);
            var query = (from o in filteredPeoples
                         select new GetPeopleForViewDto_PhoneBook()
                         {
                             Person = new PersonDto
                             {
                                 Name = o.Name,
                                 Surname = o.Surname,
                                 EmailAddress = o.EmailAddress,
                                 Id = o.Id
                             }
                         });

            var peopleListDtos = await query.ToListAsync();

            return _personExcelExporter.ExportToFile(peopleListDtos);
        }*/

    }

}
