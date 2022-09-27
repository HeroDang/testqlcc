using Abp.AutoMapper;
using Abp.Modules;
using Abp.Reflection.Extensions;

namespace Framework.Startup
{
    [DependsOn(typeof(FrameworkCoreModule))]
    public class FrameworkGraphQLModule : AbpModule
    {
        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(FrameworkGraphQLModule).GetAssembly());
        }

        public override void PreInitialize()
        {
            base.PreInitialize();

            //Adding custom AutoMapper configuration
            Configuration.Modules.AbpAutoMapper().Configurators.Add(CustomDtoMapper.CreateMappings);
        }
    }
}