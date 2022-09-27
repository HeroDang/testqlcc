using System.Threading.Tasks;
using Abp.Webhooks;

namespace Framework.WebHooks
{
    public interface IWebhookEventAppService
    {
        Task<WebhookEvent> Get(string id);
    }
}
