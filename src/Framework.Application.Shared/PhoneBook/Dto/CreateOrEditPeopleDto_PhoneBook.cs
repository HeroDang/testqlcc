using Abp.Application.Services.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace Framework.PhoneBook.Dto
{
    public class CreateOrEditPeopleDto_PhoneBook : EntityDto<int?>
    {
        public string Name { get; set; }

        public string Surname { get; set; }

        public string EmailAddress { get; set; }
    }
}
