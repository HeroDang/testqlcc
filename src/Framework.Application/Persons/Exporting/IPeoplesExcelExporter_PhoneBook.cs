using Framework.Dto;
using Framework.PhoneBook.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Framework.Persons.Exporting
{
    public interface IPeoplesExcelExporter_PhoneBook
    {
        FileDto ExportToFile(List<GetPeopleForViewDto_PhoneBook> peoples);
    }
}
