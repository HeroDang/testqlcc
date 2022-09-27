using Abp.AutoMapper;
using Framework.MultiTenancy.Dto;

namespace Framework.Web.Models.TenantRegistration
{
    [AutoMapFrom(typeof(EditionsSelectOutput))]
    public class EditionsSelectViewModel : EditionsSelectOutput
    {
    }
}
