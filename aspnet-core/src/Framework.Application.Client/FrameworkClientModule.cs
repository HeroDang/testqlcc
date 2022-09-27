using Abp.Modules;
using Abp.Reflection.Extensions;

namespace Framework
{
    public class FrameworkClientModule : AbpModule
    {
        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(FrameworkClientModule).GetAssembly());
        }
    }
}
