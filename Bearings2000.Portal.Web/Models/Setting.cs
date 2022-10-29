using System;
using System.Collections.Generic;

namespace Bearings2000.Portal.Web.Models
{
    public partial class Setting
    {
        public int SettingId { get; set; }
        public int SettingTypeMajorId { get; set; }
        public int SettingTypeIntermediateId { get; set; }
        public int SettingTypeMinorId { get; set; }
        public int StatusId { get; set; }
        public string SettingValue { get; set; } = null!;
    }
}
