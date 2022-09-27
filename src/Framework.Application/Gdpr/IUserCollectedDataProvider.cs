using System.Collections.Generic;
using System.Threading.Tasks;
using Abp;
using Framework.Dto;

namespace Framework.Gdpr
{
    public interface IUserCollectedDataProvider
    {
        Task<List<FileDto>> GetFiles(UserIdentifier user);
    }
}
