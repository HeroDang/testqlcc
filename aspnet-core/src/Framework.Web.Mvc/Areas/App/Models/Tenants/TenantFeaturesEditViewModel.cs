using Abp.AutoMapper;
using Framework.MultiTenancy;
using Framework.MultiTenancy.Dto;
using Framework.Web.Areas.App.Models.Common;

namespace Framework.Web.Areas.App.Models.Tenants
{
    [AutoMapFrom(typeof (GetTenantFeaturesEditOutput))]
    public class TenantFeaturesEditViewModel : GetTenantFeaturesEditOutput, IFeatureEditViewModel
    {
        public Tenant Tenant { get; set; }
    }
}