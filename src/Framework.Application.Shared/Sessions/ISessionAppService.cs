using System.Threading.Tasks;
using Abp.Application.Services;
using Framework.Sessions.Dto;

namespace Framework.Sessions
{
    public interface ISessionAppService : IApplicationService
    {
        Task<GetCurrentLoginInformationsOutput> GetCurrentLoginInformations();

        Task<UpdateUserSignInTokenOutput> UpdateUserSignInToken();
    }
}
