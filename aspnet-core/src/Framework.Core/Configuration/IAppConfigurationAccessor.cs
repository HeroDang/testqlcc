using Microsoft.Extensions.Configuration;

namespace Framework.Configuration
{
    public interface IAppConfigurationAccessor
    {
        IConfigurationRoot Configuration { get; }
    }
}
