using System.Collections.Generic;
using Abp;
using Framework.Chat.Dto;
using Framework.Dto;

namespace Framework.Chat.Exporting
{
    public interface IChatMessageListExcelExporter
    {
        FileDto ExportToFile(UserIdentifier user, List<ChatMessageExportDto> messages);
    }
}
