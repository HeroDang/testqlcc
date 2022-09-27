using System.Collections.Generic;
using Framework.Caching.Dto;

namespace Framework.Web.Areas.App.Models.Maintenance
{
    public class MaintenanceViewModel
    {
        public IReadOnlyList<CacheDto> Caches { get; set; }
    }
}