using System.Threading.Tasks;
using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Framework.Caching.Dto;

namespace Framework.Caching
{
    public interface ICachingAppService : IApplicationService
    {
        ListResultDto<CacheDto> GetAllCaches();

        Task ClearCache(EntityDto<string> input);

        Task ClearAllCaches();
    }
}
