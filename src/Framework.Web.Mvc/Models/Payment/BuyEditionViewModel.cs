using System.Collections.Generic;
using Framework.Editions;
using Framework.Editions.Dto;
using Framework.MultiTenancy.Payments;
using Framework.MultiTenancy.Payments.Dto;

namespace Framework.Web.Models.Payment
{
    public class BuyEditionViewModel
    {
        public SubscriptionStartType? SubscriptionStartType { get; set; }

        public EditionSelectDto Edition { get; set; }

        public decimal? AdditionalPrice { get; set; }

        public EditionPaymentType EditionPaymentType { get; set; }

        public List<PaymentGatewayModel> PaymentGateways { get; set; }
    }
}
