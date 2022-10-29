using System;
using System.Collections.Generic;

namespace Bearings2000.Portal.Web.Models
{
    public partial class OrderDetail
    {
        public int OrderDetailId { get; set; }
        public int OrderId { get; set; }
        public int? ProductId { get; set; }
        public int? Quanity { get; set; }
        public decimal? UnitPrice { get; set; }
        public int? OrderDetailStatusId { get; set; }

        public virtual Enquire Order { get; set; } = null!;
        public virtual Product? Product { get; set; }
    }
}
