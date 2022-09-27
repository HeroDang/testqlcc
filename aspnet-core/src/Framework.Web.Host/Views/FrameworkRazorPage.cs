using Abp.AspNetCore.Mvc.Views;

namespace Framework.Web.Views
{
    public abstract class FrameworkRazorPage<TModel> : AbpRazorPage<TModel>
    {
        protected FrameworkRazorPage()
        {
            LocalizationSourceName = FrameworkConsts.LocalizationSourceName;
        }
    }
}
