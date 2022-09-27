using Abp.AspNetCore.Mvc.ViewComponents;

namespace Framework.Web.Views
{
    public abstract class FrameworkViewComponent : AbpViewComponent
    {
        protected FrameworkViewComponent()
        {
            LocalizationSourceName = FrameworkConsts.LocalizationSourceName;
        }
    }
}