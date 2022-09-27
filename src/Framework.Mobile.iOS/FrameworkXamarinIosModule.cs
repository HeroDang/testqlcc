using Abp.Modules;
using Abp.Reflection.Extensions;

namespace Framework
{
    [DependsOn(typeof(FrameworkXamarinSharedModule))]
    public class FrameworkXamarinIosModule : AbpModule
    {
        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(FrameworkXamarinIosModule).GetAssembly());
        }
    }
}