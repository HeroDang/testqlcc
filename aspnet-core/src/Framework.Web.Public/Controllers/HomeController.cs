using Microsoft.AspNetCore.Mvc;
using Framework.Web.Controllers;

namespace Framework.Web.Public.Controllers
{
    public class HomeController : FrameworkControllerBase
    {
        public ActionResult Index()
        {
            return View();
        }
    }
}