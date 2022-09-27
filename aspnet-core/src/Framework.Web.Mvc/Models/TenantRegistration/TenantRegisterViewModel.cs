using Framework.Editions;
using Framework.Editions.Dto;
using Framework.MultiTenancy.Payments;
using Framework.Security;
using Framework.MultiTenancy.Payments.Dto;

namespace Framework.Web.Models.TenantRegistration
{
    public class TenantRegisterViewModel
    {
        public PasswordComplexitySetting PasswordComplexitySetting { get; set; }

        public int? EditionId { get; set; }

        public SubscriptionStartType? SubscriptionStartType { get; set; }

        public EditionSelectDto Edition { get; set; }

        public EditionPaymentType EditionPaymentType { get; set; }
    }
}
