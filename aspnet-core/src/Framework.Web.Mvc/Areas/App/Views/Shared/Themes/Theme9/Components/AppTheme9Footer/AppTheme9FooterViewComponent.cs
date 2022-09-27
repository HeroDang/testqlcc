using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Framework.Web.Areas.App.Models.Layout;
using Framework.Web.Session;
using Framework.Web.Views;

namespace Framework.Web.Areas.App.Views.Shared.Themes.Theme9.Components.AppTheme9Footer
{
    public class AppTheme9FooterViewComponent : FrameworkViewComponent
    {
        private readonly IPerRequestSessionCache _sessionCache;

        public AppTheme9FooterViewComponent(IPerRequestSessionCache sessionCache)
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
