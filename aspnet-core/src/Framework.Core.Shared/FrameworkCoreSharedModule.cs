using Abp.Modules;
using Abp.Reflection.Extensions;

namespace Framework
{
    public class FrameworkCoreSharedModule : AbpModule
    {
        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(FrameworkCoreSharedModule).GetAssembly());
        }
    }
}