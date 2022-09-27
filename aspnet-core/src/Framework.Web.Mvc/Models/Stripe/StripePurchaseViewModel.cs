using Framework.MultiTenancy.Payments.Stripe;

namespace Framework.Web.Models.Stripe
{
    public class StripePurchaseViewModel
    {
        public long PaymentId { get; set; }

        public string Description { get; set; }

        public decimal Amount { get; set; }

        public bool IsRecurring { get; set; }

        public bool UpdateSubscription { get; set; }

        public string SessionId { get; set; }

        public StripePaymentGatewayConfiguration Configuration { get; set; }
    }
}
