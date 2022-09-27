using Abp.Authorization;
using Framework.Authorization.Roles;
using Framework.Authorization.Users;

namespace Framework.Authorization
{
    public class PermissionChecker : PermissionChecker<Role, User>
    {
        public PermissionChecker(UserManager userManager)
            : base(userManager)
        {

        }
    }
}
