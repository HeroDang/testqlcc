using System;
using Abp.Application.Services.Dto;
using System.ComponentModel.DataAnnotations;

namespace Framework.Admin.Dtos
{
    public class CreateOrEditPeopleDto : EntityDto<int?>
    {

        public string Name { get; set; }

    }
}