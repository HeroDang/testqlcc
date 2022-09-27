using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Framework.Web.Areas.App.Models.Layout;
using Framework.Web.Views;

namespace Framework.Web.Areas.App.Views.Shared.Components.
    AppQuickThemeSelect
{
    public class AppQuickThemeSelectViewComponent : FrameworkViewComponent
    {
        public Task<IViewComponentResult> InvokeAsync(string cssClass)
        {
            return Task.FromResult<IViewComponentResult>(View(new QuickThemeSelectionViewModel
            {
                CssClass = cssClass
            }));
        }
    }
}
