using Abp.Application.Services.Dto;
using Abp.Application.Services;
using System;
using System.Collections.Generic;
using System.Text;
using Framework.PhoneBook.Dto;
using Abp.ObjectMapping;
using System.Threading.Tasks;
using Framework.Dto;
using Framework.Admin.Dtos;

namespace Framework.PhoneBook
{
    public interface IPersonAppService : IApplicationService
    {
        ListResultDto<PersonListDto> GetPeople(GetPeopleInput input);

        Task CreatePerson(CreatePersonInput input);

        Task DeletePerson(EntityDto input);

        Task DeletePhone(EntityDto<long> input);
        Task<PhoneInPersonListDto> AddPhone(AddPhoneInput input);

        Task<PagedResultDto<GetPeopleForViewDto_PhoneBook>> GetAll(GetAllPeoplesInput_PhoneBook input);

        Task<GetPeopleForEditOutput_PhoneBook> GetPeopleForEdit(EntityDto input);

        //Task CreateOrEdit(CreateOrEditPeopleDto_PhoneBook input);

        //Task Delete(EntityDto input);

        Task<FileDto> GetPeoplesToExcel(GetAllPeoplesForExcelInput_PhoneBook input);
    }

}
