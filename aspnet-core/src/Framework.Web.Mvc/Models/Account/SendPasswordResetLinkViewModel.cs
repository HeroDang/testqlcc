using System.ComponentModel.DataAnnotations;

namespace Framework.Web.Models.Account
{
    public class SendPasswordResetLinkViewModel
    {
        [Required]
        public string EmailAddress { get; set; }
    }
}