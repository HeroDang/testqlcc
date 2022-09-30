using Abp.Application.Services.Dto;

namespace Framework.Admin.Dtos
{
    public class GetAllForLookupTableInput : PagedAndSortedResultRequestDto
    {
        public string Filter { get; set; }
    }
}