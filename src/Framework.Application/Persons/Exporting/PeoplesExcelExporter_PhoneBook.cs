using Abp.Runtime.Session;
using Abp.Timing.Timezone;
using Framework.DataExporting.Excel.NPOI;
using Framework.Dto;
using Framework.PhoneBook.Dto;
using Framework.Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Framework.Persons.Exporting
{
    public class PeoplesExcelExporter_PhoneBook : NpoiExcelExporterBase, IPeoplesExcelExporter_PhoneBook
    {

        private readonly ITimeZoneConverter _timeZoneConverter;
        private readonly IAbpSession _abpSession;

        public PeoplesExcelExporter_PhoneBook(
            ITimeZoneConverter timeZoneConverter,
            IAbpSession abpSession,
            ITempFileCacheManager tempFileCacheManager) :
    base(tempFileCacheManager)
        {
            _timeZoneConverter = timeZoneConverter;
            _abpSession = abpSession;
        }

        public FileDto ExportToFile(List<GetPeopleForViewDto_PhoneBook> peoples)
        {
            return CreateExcelPackage(
                "Peoples.xlsx",
                excelPackage =>
                {

                    var sheet = excelPackage.CreateSheet(L("Peoples"));

                    AddHeader(
                        sheet,
                        L("Name"),
                        L("Surname"),
                        L("EmailAddress")
                        );

                    AddObjects(
                        sheet, 2, peoples,
                        _ => _.Person.Name,
                        _ => _.Person.Surname,
                        _ => _.Person.EmailAddress
                        );

                    /*
                      AddHeader(
                        sheet,
                        L("Time"),
                        L("UserName"),
                        L("Service"),
                        L("Action"),
                        L("Parameters"),
                        L("Duration"),
                        L("IpAddress"),
                        L("Client"),
                        L("Browser"),
                        L("ErrorState")
                    );

                    AddObjects(
                        sheet, 2, auditLogListDtos,
                        _ => _timeZoneConverter.Convert(_.ExecutionTime, _abpSession.TenantId, _abpSession.GetUserId()),
                        _ => _.UserName,
                        _ => _.ServiceName,
                        _ => _.MethodName,
                        _ => _.Parameters,
                        _ => _.ExecutionDuration,
                        _ => _.ClientIpAddress,
                        _ => _.ClientName,
                        _ => _.BrowserInfo,
                        _ => _.Exception.IsNullOrEmpty() ? L("Success") : _.Exception
                        );
                    
                     */

                });
        }
    }
}
