using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Framework.Authorization.Delegation;
using Framework.Authorization.Users.Delegation;
using Framework.Web.Areas.App.Models.Layout;
using Framework.Web.Views;

namespace Framework.Web.Areas.App.Views.Shared.Components.AppActiveUserDelegationsCombobox
{
    public class AppActiveUserDelegationsComboboxViewComponent : FrameworkViewComponent
    {
        private readonly IUserDelegationAppService _userDelegationAppService;
        private readonly IUserDelegationConfiguration _userDelegationConfiguration;

        public AppActiveUserDelegationsComboboxViewComponent(
            IUserDelegationAppService userDelegationAppService, 
            IUserDelegationConfiguration userDelegationConfiguration)
        {
            _userDelegationAppService = userDelegationAppService;
            _userDelegationConfiguration = userDelegationConfiguration;
        }

        public async Task<IViewComponentResult> InvokeAsync(string logoSkin = null, string logoClass = "")
        {
            var activeUserDelegations = await _userDelegationAppService.GetActiveUserDelegations();
            var model = new ActiveUserDelegationsComboboxViewModel
            {
                UserDelegations = activeUserDelegations,
                UserDelegationConfiguration = _userDelegationConfiguration
            };

            return View(model);
        }
    }
}
