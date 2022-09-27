using Microsoft.AspNetCore.Mvc;
using Framework.Web.Controllers;

namespace Framework.Web.Public.Controllers
{
    public class AboutController : FrameworkControllerBase
    {
        public ActionResult Index()
        {
            return View();
        }
    }
}