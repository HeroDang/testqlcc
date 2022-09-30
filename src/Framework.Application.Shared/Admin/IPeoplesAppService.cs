using System;
using System.Threading.Tasks;
using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Framework.Admin.Dtos;
using Framework.Dto;

namespace Framework.Admin
{
    public interface IPeoplesAppService : IApplicationService
    {
        Task<PagedResultDto<GetPeopleForViewDto>> GetAll(GetAllPeoplesInput input);

        Task<GetPeopleForViewDto> GetPeopleForView(int id);

        Task<GetPeopleForEditOutput> GetPeopleForEdit(EntityDto input);

        Task CreateOrEdit(CreateOrEditPeopleDto input);

        Task Delete(EntityDto input);

        Task<FileDto> GetPeoplesToExcel(GetAllPeoplesForExcelInput input);

    }
}