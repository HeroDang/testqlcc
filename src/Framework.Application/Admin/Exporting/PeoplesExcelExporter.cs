using System.Collections.Generic;
using Abp.Runtime.Session;
using Abp.Timing.Timezone;
using Framework.DataExporting.Excel.NPOI;
using Framework.Admin.Dtos;
using Framework.Dto;
using Framework.Storage;

namespace Framework.Admin.Exporting
{
    public class PeoplesExcelExporter : NpoiExcelExporterBase, IPeoplesExcelExporter
    {

        private readonly ITimeZoneConverter _timeZoneConverter;
        private readonly IAbpSession _abpSession;

        public PeoplesExcelExporter(
            ITimeZoneConverter timeZoneConverter,
            IAbpSession abpSession,
            ITempFileCacheManager tempFileCacheManager) :
    base(tempFileCacheManager)
        {
            _timeZoneConverter = timeZoneConverter;
            _abpSession = abpSession;
        }

        public FileDto ExportToFile(List<GetPeopleForViewDto> peoples)
        {
            return CreateExcelPackage(
                "Peoples.xlsx",
                excelPackage =>
                {

                    var sheet = excelPackage.CreateSheet(L("Peoples"));

                    AddHeader(
                        sheet,
                        L("Name")
                        );

                    AddObjects(
                        sheet, 2, peoples,
                        _ => _.People.Name
                        );

                });
        }
    }
}