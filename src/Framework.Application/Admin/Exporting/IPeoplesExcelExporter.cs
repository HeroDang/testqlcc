using System.Collections.Generic;
using Framework.Admin.Dtos;
using Framework.Dto;

namespace Framework.Admin.Exporting
{
    public interface IPeoplesExcelExporter
    {
        FileDto ExportToFile(List<GetPeopleForViewDto> peoples);
    }
}