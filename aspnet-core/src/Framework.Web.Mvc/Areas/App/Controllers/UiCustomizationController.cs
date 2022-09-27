using System.Threading.Tasks;
using Abp.AspNetCore.Mvc.Authorization;
using Microsoft.AspNetCore.Mvc;
using Framework.Authorization;
using Framework.Configuration;
using Framework.Web.Areas.App.Models.UiCustomization;
using Framework.Web.Controllers;

namespace Framework.Web.Areas.App.Controllers
{
    [Area("App")]
    [AbpMvcAuthorize]
    public class UiCustomizationController : FrameworkControllerBase
    {
        private readonly IUiCustomizationSettingsAppService _uiCustomizationAppService;

        public UiCustomizationController(IUiCustomizationSettingsAppService uiCustomizationAppService)
        {
            _uiCustomizationAppService = uiCustomizationAppService;
        }

        public async Task<ActionResult> Index()
        {
            var model = new UiCustomizationViewModel
            {
                Theme = await SettingManager.GetSettingValueAsync(AppSettings.UiManagement.Theme),
                Settings = await _uiCustomizationAppService.GetUiManagementSettings(),
                HasUiCustomizationPagePermission = await PermissionChecker.IsGrantedAsync(AppPermissions.Pages_Administration_UiCustomization)
            };

            return View(model);
        }
    }
}