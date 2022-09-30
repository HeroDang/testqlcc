using Abp.Application.Services.Dto;
using System;

namespace Framework.Admin.Dtos
{
    public class GetAllPeoplesInput : PagedAndSortedResultRequestDto
    {
        public string Filter { get; set; }

        public string NameFilter { get; set; }

    }
}