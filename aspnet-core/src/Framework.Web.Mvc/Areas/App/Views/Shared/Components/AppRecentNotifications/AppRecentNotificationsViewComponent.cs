using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Framework.Web.Areas.App.Models.Layout;
using Framework.Web.Views;

namespace Framework.Web.Areas.App.Views.Shared.Components.AppRecentNotifications
{
    public class AppRecentNotificationsViewComponent : FrameworkViewComponent
    {
        public Task<IViewComponentResult> InvokeAsync(string cssClass)
        {
            var model = new RecentNotificationsViewModel
            {
                CssClass = cssClass
            };
            
            return Task.FromResult<IViewComponentResult>(View(model));
        }
    }
}
