using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Framework.Authorization.Permissions.Dto;

namespace Framework.Authorization.Permissions
{
    public interface IPermissionAppService : IApplicationService
    {
        ListResultDto<FlatPermissionWithLevelDto> GetAllPermissions();
    }
}
