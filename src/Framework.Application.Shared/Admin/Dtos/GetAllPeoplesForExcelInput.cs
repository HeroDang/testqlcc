using Abp.Application.Services.Dto;
using System;

namespace Framework.Admin.Dtos
{
    public class GetAllPeoplesForExcelInput
    {
        public string Filter { get; set; }

        public string NameFilter { get; set; }

    }
}