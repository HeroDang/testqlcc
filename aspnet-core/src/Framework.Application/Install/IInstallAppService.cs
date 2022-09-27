using System.Threading.Tasks;
using Abp.Application.Services;
using Framework.Install.Dto;

namespace Framework.Install
{
    public interface IInstallAppService : IApplicationService
    {
        Task Setup(InstallDto input);

        AppSettingsJsonDto GetAppSettingsJson();

        CheckDatabaseOutput CheckDatabase();
    }
}