using System;
using Abp.IdentityServer4vNext;
using IdentityServer4.Configuration;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Framework.Authorization.Users;
using Framework.EntityFrameworkCore;

namespace Framework.Web.IdentityServer
{
    public static class IdentityServerRegistrar
    {
        public static void Register(IServiceCollection services, IConfigurationRoot configuration, Action<IdentityServerOptions> setupOptions)
        {
            services.AddIdentityServer(setupOptions)
                .AddDeveloperSigningCredential()
                .AddInMemoryIdentityResources(IdentityServerConfig.GetIdentityResources())
                .AddInMemoryApiScopes(IdentityServerConfig.GetApiScopes())
                .AddInMemoryApiResources(IdentityServerConfig.GetApiResources())
                .AddInMemoryClients(IdentityServerConfig.GetClients(configuration))
                .AddAbpPersistedGrants<FrameworkDbContext>()
                .AddAbpIdentityServer<User>();
        }

        public static void Register(IServiceCollection services, IConfigurationRoot configuration)
        {
            Register(services, configuration, options => { });
        }
    }
}
