using Abp.AutoMapper;
using Framework.Authorization.Roles.Dto;
using Framework.Web.Areas.App.Models.Common;

namespace Framework.Web.Areas.App.Models.Roles
{
    [AutoMapFrom(typeof(GetRoleForEditOutput))]
    public class CreateOrEditRoleModalViewModel : GetRoleForEditOutput, IPermissionsEditViewModel
    {
        public bool IsEditMode => Role.Id.HasValue;
    }
}