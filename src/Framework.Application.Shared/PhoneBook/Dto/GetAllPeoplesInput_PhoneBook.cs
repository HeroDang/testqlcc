using Abp.Application.Services.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace Framework.PhoneBook.Dto
{
    public class GetAllPeoplesInput_PhoneBook : PagedAndSortedResultRequestDto
    {
        public string Filter { get; set; }

        public string NameFilter { get; set; }
    }
}
