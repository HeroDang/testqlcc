using System.Collections.Generic;
using Framework.Authorization.Users.Importing.Dto;
using Framework.Dto;

namespace Framework.Authorization.Users.Importing
{
    public interface IInvalidUserExporter
    {
        FileDto ExportToFile(List<ImportUserDto> userListDtos);
    }
}
