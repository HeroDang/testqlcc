using Abp.AutoMapper;
using Abp.Modules;
using Abp.Reflection.Extensions;

namespace Framework
{
    [DependsOn(typeof(FrameworkClientModule), typeof(AbpAutoMapperModule))]
    public class FrameworkXamarinSharedModule : AbpModule
    {
        public override void PreInitialize()
        {
            Configuration.Localization.IsEnabled = false;
            Configuration.BackgroundJobs.IsJobExecutionEnabled = false;
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(FrameworkXamarinSharedModule).GetAssembly());
        }
    }
}