using System.Collections.Generic;
using Framework.Authorization.Users.Importing.Dto;
using Abp.Dependency;

namespace Framework.Authorization.Users.Importing
{
    public interface IUserListExcelDataReader: ITransientDependency
    {
        List<ImportUserDto> GetUsersFromExcel(byte[] fileBytes);
    }
}
