using Abp.AspNetCore.Mvc.Authorization;
using Framework.Authorization;
using Framework.Storage;
using Abp.BackgroundJobs;
using Abp.Authorization;

namespace Framework.Web.Controllers
{
    [AbpMvcAuthorize(AppPermissions.Pages_Administration_Users)]
    public class UsersController : UsersControllerBase
    {
        public UsersController(IBinaryObjectManager binaryObjectManager, IBackgroundJobManager backgroundJobManager)
            : base(binaryObjectManager, backgroundJobManager)
        {
        }
    }
}