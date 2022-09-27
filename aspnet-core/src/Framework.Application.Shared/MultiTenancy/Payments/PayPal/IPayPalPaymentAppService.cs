using System.Threading.Tasks;
using Abp.Application.Services;
using Framework.MultiTenancy.Payments.PayPal.Dto;

namespace Framework.MultiTenancy.Payments.PayPal
{
    public interface IPayPalPaymentAppService : IApplicationService
    {
        Task ConfirmPayment(long paymentId, string paypalOrderId);

        PayPalConfigurationDto GetConfiguration();
    }
}
