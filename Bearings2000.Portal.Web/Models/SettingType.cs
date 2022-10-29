using System;
using System.Collections.Generic;

namespace Bearings2000.Portal.Web.Models
{
    public partial class SettingType
    {
        public int SettingTypeId { get; set; }
        public string SettingTypeDescription { get; set; } = null!;
        public int StatusId { get; set; }
        public string? Comments { get; set; }
    }
}
