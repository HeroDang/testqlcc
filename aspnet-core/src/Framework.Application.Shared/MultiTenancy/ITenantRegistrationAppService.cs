using System.Threading.Tasks;
using Abp.Application.Services;
using Framework.Editions.Dto;
using Framework.MultiTenancy.Dto;

namespace Framework.MultiTenancy
{
    public interface ITenantRegistrationAppService: IApplicationService
    {
        Task<RegisterTenantOutput> RegisterTenant(RegisterTenantInput input);

        Task<EditionsSelectOutput> GetEditionsForSelect();

        Task<EditionSelectDto> GetEdition(int editionId);
    }
}