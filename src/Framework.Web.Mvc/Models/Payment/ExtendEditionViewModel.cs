using System.Collections.Generic;
using Framework.Editions.Dto;
using Framework.MultiTenancy.Payments;

namespace Framework.Web.Models.Payment
{
    public class ExtendEditionViewModel
    {
        public EditionSelectDto Edition { get; set; }

        public List<PaymentGatewayModel> PaymentGateways { get; set; }
    }
}