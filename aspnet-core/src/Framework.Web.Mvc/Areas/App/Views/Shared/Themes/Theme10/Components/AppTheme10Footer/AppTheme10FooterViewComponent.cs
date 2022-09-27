using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Framework.Web.Areas.App.Models.Layout;
using Framework.Web.Session;
using Framework.Web.Views;

namespace Framework.Web.Areas.App.Views.Shared.Themes.Theme10.Components.AppTheme10Footer
{
    public class AppTheme10FooterViewComponent : FrameworkViewComponent
    {
        private readonly IPerRequestSessionCache _sessionCache;

        public AppTheme10FooterViewComponent(IPerRequestSessionCache sessionCache)
        {
            _sessionCache = sessionCache;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var footerModel = new FooterViewModel
            {
                LoginInformations = await _sessionCache.GetCurrentLoginInformationsAsync()
            };

            return View(footerModel);
        }
    }
}
