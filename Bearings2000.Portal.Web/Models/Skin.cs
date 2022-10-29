using System;
using System.Collections.Generic;

namespace Bearings2000.Portal.Web.Models
{
    public partial class Skin
    {
        public int SkinId { get; set; }
        public string? SkinName { get; set; }
        public string? ThemeName { get; set; }
        public string? LogoUrl { get; set; }
        public string? CompanyName { get; set; }
        public string? ByLine { get; set; }
        public bool? Active { get; set; }
        public string? DatabaseName { get; set; }
        public string? Cssname { get; set; }
    }
}
