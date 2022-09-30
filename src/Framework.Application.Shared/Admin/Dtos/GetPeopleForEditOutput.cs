using System;
using Abp.Application.Services.Dto;
using System.ComponentModel.DataAnnotations;

namespace Framework.Admin.Dtos
{
    public class GetPeopleForEditOutput
    {
        public CreateOrEditPeopleDto People { get; set; }

    }
}