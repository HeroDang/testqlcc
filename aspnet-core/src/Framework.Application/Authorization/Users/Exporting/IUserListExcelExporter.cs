using System.Collections.Generic;
using Framework.Authorization.Users.Dto;
using Framework.Dto;

namespace Framework.Authorization.Users.Exporting
{
    public interface IUserListExcelExporter
    {
        FileDto ExportToFile(List<UserListDto> userListDtos);
    }
}