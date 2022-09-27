using Abp.Modules;
using Abp.Reflection.Extensions;

namespace Framework
{
    [DependsOn(typeof(FrameworkXamarinSharedModule))]
    public class FrameworkXamarinAndroidModule : AbpModule
    {
        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(FrameworkXamarinAndroidModule).GetAssembly());
        }
    }
}