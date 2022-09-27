using System.Threading.Tasks;
using Framework.Sessions.Dto;

namespace Framework.Web.Session
{
    public interface IPerRequestSessionCache
    {
        Task<GetCurrentLoginInformationsOutput> GetCurrentLoginInformationsAsync();
    }
}
