using System.Threading.Tasks;
using Abp.Application.Services;
using Framework.MultiTenancy.Payments.Dto;
using Framework.MultiTenancy.Payments.Stripe.Dto;

namespace Framework.MultiTenancy.Payments.Stripe
{
    public interface IStripePaymentAppService : IApplicationService
    {
        Task ConfirmPayment(StripeConfirmPaymentInput input);

        StripeConfigurationDto GetConfiguration();

        Task<SubscriptionPaymentDto> GetPaymentAsync(StripeGetPaymentInput input);

        Task<string> CreatePaymentSession(StripeCreatePaymentSessionInput input);
    }
}