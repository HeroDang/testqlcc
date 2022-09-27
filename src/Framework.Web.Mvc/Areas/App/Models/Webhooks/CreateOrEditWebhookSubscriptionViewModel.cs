using Abp.Application.Services.Dto;
using Abp.Webhooks;
using Framework.WebHooks.Dto;

namespace Framework.Web.Areas.App.Models.Webhooks
{
    public class CreateOrEditWebhookSubscriptionViewModel
    {
        public WebhookSubscription WebhookSubscription { get; set; }

        public ListResultDto<GetAllAvailableWebhooksOutput> AvailableWebhookEvents { get; set; }
    }
}
