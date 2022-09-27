using System.Threading.Tasks;
using Framework.Authorization.Users;

namespace Framework.WebHooks
{
    public interface IAppWebhookPublisher
    {
        Task PublishTestWebhook();
    }
}
