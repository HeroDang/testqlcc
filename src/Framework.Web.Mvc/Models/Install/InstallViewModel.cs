using System.Collections.Generic;
using Abp.Localization;
using Framework.Install.Dto;

namespace Framework.Web.Models.Install
{
    public class InstallViewModel
    {
        public List<ApplicationLanguage> Languages { get; set; }

        public AppSettingsJsonDto AppSettingsJson { get; set; }
    }
}
