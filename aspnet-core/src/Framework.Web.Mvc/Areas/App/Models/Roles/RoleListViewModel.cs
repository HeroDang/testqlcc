using System.Collections.Generic;
using Abp.Application.Services.Dto;
using Framework.Authorization.Permissions.Dto;
using Framework.Web.Areas.App.Models.Common;

namespace Framework.Web.Areas.App.Models.Roles
{
    public class RoleListViewModel : IPermissionsEditViewModel
    {
        public List<FlatPermissionDto> Permissions { get; set; }

        public List<string> GrantedPermissionNames { get; set; }
    }
}