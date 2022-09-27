using System.Collections.Generic;
using Framework.Authorization.Delegation;
using Framework.Authorization.Users.Delegation.Dto;

namespace Framework.Web.Areas.App.Models.Layout
{
    public class ActiveUserDelegationsComboboxViewModel
    {
        public IUserDelegationConfiguration UserDelegationConfiguration { get; set; }
        
        public List<UserDelegationDto> UserDelegations { get; set; }
    }
}
