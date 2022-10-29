using System;
using System.Collections.Generic;

namespace Bearings2000.Portal.Web.Models
{
    public partial class Menu
    {
        public int MenuId { get; set; }
        public string? MenuText { get; set; }
        public string? MenuName { get; set; }
        public string? MenuUrl { get; set; }
        public string? MenuTarget { get; set; }
        public string? MenuImageUrl { get; set; }
        public int? MenuParentId { get; set; }
        public decimal? SortSequence { get; set; }
        public bool? Active { get; set; }
    }
}
