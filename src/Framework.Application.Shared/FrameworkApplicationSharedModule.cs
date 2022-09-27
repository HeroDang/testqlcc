using Abp.Modules;
using Abp.Reflection.Extensions;

namespace Framework
{
    [DependsOn(typeof(FrameworkCoreSharedModule))]
    public class FrameworkApplicationSharedModule : AbpModule
    {
        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(FrameworkApplicationSharedModule).GetAssembly());
        }
    }
}