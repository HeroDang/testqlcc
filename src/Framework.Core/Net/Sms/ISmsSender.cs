using System.Threading.Tasks;

namespace Framework.Net.Sms
{
    public interface ISmsSender
    {
        Task SendAsync(string number, string message);
    }
}