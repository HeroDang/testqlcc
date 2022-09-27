using System.Threading.Tasks;
using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Framework.Common.Dto;
using Framework.Editions.Dto;

namespace Framework.Common
{
    public interface ICommonLookupAppService : IApplicationService
    {
        Task<ListResultDto<SubscribableEditionComboboxItemDto>> GetEditionsForCombobox(bool onlyFreeItems = false);

        Task<PagedResultDto<NameValueDto>> FindUsers(FindUsersInput input);

        GetDefaultEditionNameOutput GetDefaultEditionName();
    }
}