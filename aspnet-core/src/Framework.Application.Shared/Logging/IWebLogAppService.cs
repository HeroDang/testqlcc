using Abp.Application.Services;
using Framework.Dto;
using Framework.Logging.Dto;

namespace Framework.Logging
{
    public interface IWebLogAppService : IApplicationService
    {
        GetLatestWebLogsOutput GetLatestWebLogs();

        FileDto DownloadWebLogs();
    }
}
