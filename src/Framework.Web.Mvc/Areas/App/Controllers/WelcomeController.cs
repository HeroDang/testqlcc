using Abp.AspNetCore.Mvc.Authorization;
using Microsoft.AspNetCore.Mvc;
using Framework.Web.Controllers;

namespace Framework.Web.Areas.App.Controllers
{
    [Area("App")]
    [AbpMvcAuthorize]
    public class WelcomeController : FrameworkControllerBase
    {
        public ActionResult Index()
        {
            return View();
        }
    }
}