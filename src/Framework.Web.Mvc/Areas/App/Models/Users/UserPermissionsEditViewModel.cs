using Abp.AutoMapper;
using Framework.Authorization.Users;
using Framework.Authorization.Users.Dto;
using Framework.Web.Areas.App.Models.Common;

namespace Framework.Web.Areas.App.Models.Users
{
    [AutoMapFrom(typeof(GetUserPermissionsForEditOutput))]
    public class UserPermissionsEditViewModel : GetUserPermissionsForEditOutput, IPermissionsEditViewModel
    {
        public User User { get; set; }
    }
}