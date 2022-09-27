using Abp.Modules;
using Abp.Reflection.Extensions;
using Castle.Windsor.MsDependencyInjection;
using Microsoft.Extensions.DependencyInjection;
using Framework.Configure;
using Framework.Startup;
using Framework.Test.Base;

namespace Framework.GraphQL.Tests
{
    [DependsOn(
        typeof(FrameworkGraphQLModule),
        typeof(FrameworkTestBaseModule))]
    public class FrameworkGraphQLTestModule : AbpModule
    {
        public override void PreInitialize()
        {
            IServiceCollection services = new ServiceCollection();
            
            services.AddAndConfigureGraphQL();

            WindsorRegistrationHelper.CreateServiceProvider(IocManager.IocContainer, services);
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(FrameworkGraphQLTestModule).GetAssembly());
        }
    }
}