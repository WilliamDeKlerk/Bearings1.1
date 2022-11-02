using Bearings2000.Portal.Web.Areas.Identity.Data;
using System;
using System.Collections.Generic;

namespace Bearings2000.Portal.Web.Models
{
    public partial class Enquire
    {
        public Enquire()
        {
            EnquiryDetails = new HashSet<EnquiryDetail>();
            OrderDetails = new HashSet<OrderDetail>();
        }
        public AppUser AppUser { get; set; }
        public int EquiryId { get; set; }
        public int? UserId { get; set; }
        public int? CustomerId { get; set; }
        public DateTime? EnquiryCreatedDate { get; set; }
        public DateTime? EnquiryProcessedDate { get; set; }
        public int? EnquiryStatusId { get; set; }
        public string? Comment { get; set; }

        public virtual Customer? Customer { get; set; }
        public virtual User? User { get; set; }
        public virtual ICollection<EnquiryDetail> EnquiryDetails { get; set; }
        public virtual ICollection<OrderDetail> OrderDetails { get; set; }
    }
}
