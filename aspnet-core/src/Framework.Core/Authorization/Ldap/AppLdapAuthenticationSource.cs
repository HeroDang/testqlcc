using Abp.Zero.Ldap.Authentication;
using Abp.Zero.Ldap.Configuration;
using Framework.Authorization.Users;
using Framework.MultiTenancy;

namespace Framework.Authorization.Ldap
{
    public class AppLdapAuthenticationSource : LdapAuthenticationSource<Tenant, User>
    {
        public AppLdapAuthenticationSource(ILdapSettings settings, IAbpZeroLdapModuleConfig ldapModuleConfig)
            : base(settings, ldapModuleConfig)
        {
        }
    }
}