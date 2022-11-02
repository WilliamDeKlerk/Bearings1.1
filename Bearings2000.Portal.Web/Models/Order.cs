using Bearings2000.Portal.Web.Areas.Identity.Data;
using System;
using System.Collections.Generic;

namespace Bearings2000.Portal.Web.Models
{
    public partial class Order
    {
        public int OrderId { get; set; }
        public int? UserId { get; set; }
        public AppUser AppUser { get; set; }
        public int? CustomerId { get; set; }
        public DateTime? OrderCreatedDate { get; set; }
        public DateTime? OrderProcessedDate { get; set; }
        public int? OrderStatusId { get; set; }
        public string? Comment { get; set; }
        public string? DocumentPath { get; set; }

        public virtual Customer? Customer { get; set; }
        public virtual User? User { get; set; }
    }
}
