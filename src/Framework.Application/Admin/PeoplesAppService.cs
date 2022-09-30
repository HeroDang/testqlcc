using System;
using System.Linq;
using System.Linq.Dynamic.Core;
using Abp.Linq.Extensions;
using System.Collections.Generic;
using System.Threading.Tasks;
using Abp.Domain.Repositories;
using Framework.Admin.Exporting;
using Framework.Admin.Dtos;
using Framework.Dto;
using Abp.Application.Services.Dto;
using Framework.Authorization;
using Abp.Extensions;
using Abp.Authorization;
using Microsoft.EntityFrameworkCore;
using Abp.UI;
using Framework.Storage;

namespace Framework.Admin
{
    [AbpAuthorize(AppPermissions.Pages_Peoples)]
    public class PeoplesAppService : FrameworkAppServiceBase, IPeoplesAppService
    {
        private readonly IRepository<People> _peopleRepository;
        private readonly IPeoplesExcelExporter _peoplesExcelExporter;

        public PeoplesAppService(IRepository<People> peopleRepository, IPeoplesExcelExporter peoplesExcelExporter)
        {
            _peopleRepository = peopleRepository;
            _peoplesExcelExporter = peoplesExcelExporter;

        }

        public async Task<PagedResultDto<GetPeopleForViewDto>> GetAll(GetAllPeoplesInput input)
        {

            var filteredPeoples = _peopleRepository.GetAll()
                        .WhereIf(!string.IsNullOrWhiteSpace(input.Filter), e => false || e.Name.Contains(input.Filter))
                        .WhereIf(!string.IsNullOrWhiteSpace(input.NameFilter), e => e.Name == input.NameFilter);

            var pagedAndFilteredPeoples = filteredPeoples
                .OrderBy(input.Sorting ?? "id asc")
                .PageBy(input);

            var peoples = from o in pagedAndFilteredPeoples
                          select new
                          {

                              o.Name,
                              Id = o.Id
                          };

            var totalCount = await filteredPeoples.CountAsync();

            var dbList = await peoples.ToListAsync();
            var results = new List<GetPeopleForViewDto>();

            foreach (var o in dbList)
            {
                var res = new GetPeopleForViewDto()
                {
                    People = new PeopleDto
                    {

                        Name = o.Name,
                        Id = o.Id,
                    }
                };

                results.Add(res);
            }

            return new PagedResultDto<GetPeopleForViewDto>(
                totalCount,
                results
            );

        }

        public async Task<GetPeopleForViewDto> GetPeopleForView(int id)
        {
            var people = await _peopleRepository.GetAsync(id);

            var output = new GetPeopleForViewDto { People = ObjectMapper.Map<PeopleDto>(people) };

            return output;
        }

        [AbpAuthorize(AppPermissions.Pages_Peoples_Edit)]
        public async Task<GetPeopleForEditOutput> GetPeopleForEdit(EntityDto input)
        {
            var people = await _peopleRepository.FirstOrDefaultAsync(input.Id);

            var output = new GetPeopleForEditOutput { People = ObjectMapper.Map<CreateOrEditPeopleDto>(people) };

            return output;
        }

        public async Task CreateOrEdit(CreateOrEditPeopleDto input)
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

        [AbpAuthorize(AppPermissions.Pages_Peoples_Create)]
        protected virtual async Task Create(CreateOrEditPeopleDto input)
        {
            var people = ObjectMapper.Map<People>(input);

            if (AbpSession.TenantId != null)
            {
                people.TenantId = (int?)AbpSession.TenantId;
            }

            await _peopleRepository.InsertAsync(people);

        }

        [AbpAuthorize(AppPermissions.Pages_Peoples_Edit)]
        protected virtual async Task Update(CreateOrEditPeopleDto input)
        {
            var people = await _peopleRepository.FirstOrDefaultAsync((int)input.Id);
            ObjectMapper.Map(input, people);

        }

        [AbpAuthorize(AppPermissions.Pages_Peoples_Delete)]
        public async Task Delete(EntityDto input)
        {
            await _peopleRepository.DeleteAsync(input.Id);
        }

        public async Task<FileDto> GetPeoplesToExcel(GetAllPeoplesForExcelInput input)
        {

            var filteredPeoples = _peopleRepository.GetAll()
                        .WhereIf(!string.IsNullOrWhiteSpace(input.Filter), e => false || e.Name.Contains(input.Filter))
                        .WhereIf(!string.IsNullOrWhiteSpace(input.NameFilter), e => e.Name == input.NameFilter);

            var query = (from o in filteredPeoples
                         select new GetPeopleForViewDto()
                         {
                             People = new PeopleDto
                             {
                                 Name = o.Name,
                                 Id = o.Id
                             }
                         });

            var peopleListDtos = await query.ToListAsync();

            return _peoplesExcelExporter.ExportToFile(peopleListDtos);
        }

    }
}