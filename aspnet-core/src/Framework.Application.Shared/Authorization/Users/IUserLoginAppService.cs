using System.Threading.Tasks;
using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Framework.Authorization.Users.Dto;

namespace Framework.Authorization.Users
{
    public interface IUserLoginAppService : IApplicationService
    {
        Task<ListResultDto<UserLoginAttemptDto>> GetRecentUserLoginAttempts();
    }
}
