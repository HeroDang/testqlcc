using System.Collections.Generic;
using MvvmHelpers;
using Framework.Models.NavigationMenu;

namespace Framework.Services.Navigation
{
    public interface IMenuProvider
    {
        ObservableRangeCollection<NavigationMenuItem> GetAuthorizedMenuItems(Dictionary<string, string> grantedPermissions);
    }
}