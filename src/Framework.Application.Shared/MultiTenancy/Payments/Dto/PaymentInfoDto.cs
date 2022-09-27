using Framework.Editions.Dto;

namespace Framework.MultiTenancy.Payments.Dto
{
    public class PaymentInfoDto
    {
        public EditionSelectDto Edition { get; set; }

        public decimal AdditionalPrice { get; set; }

        public bool IsLessThanMinimumUpgradePaymentAmount()
        {
            return AdditionalPrice < FrameworkConsts.MinimumUpgradePaymentAmount;
        }
    }
}
