using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Framework.Web.Areas.App.Models.Layout;
using Framework.Web.Views;

namespace Framework.Web.Areas.App.Views.Shared.Components.AppChatToggler
{
    public class AppChatTogglerViewComponent : FrameworkViewComponent
    {
        public Task<IViewComponentResult> InvokeAsync(string cssClass)
        {
            return Task.FromResult<IViewComponentResult>(View(new ChatTogglerViewModel
            {
                CssClass = cssClass
            }));
        }
    }
}
