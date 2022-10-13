using Abp.Application.Services.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace Framework.PhoneBook.Dto
{
    public class PhoneInPersonListDto : CreationAuditedEntityDto<long>
    {
        public PhoneType Type { get; set; }

        public string Number { get; set; }
    }
}
