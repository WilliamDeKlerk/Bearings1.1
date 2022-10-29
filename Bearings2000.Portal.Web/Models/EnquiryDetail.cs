using System;
using System.Collections.Generic;

namespace Bearings2000.Portal.Web.Models
{
    public partial class EnquiryDetail
    {
        public int EnquiryDetailId { get; set; }
        public int EnquiryId { get; set; }
        public int? ProductId { get; set; }
        public int? QuantityRequested { get; set; }
        public decimal? UnitPriceRequested { get; set; }
        public int? QuanityApproved { get; set; }
        public decimal? UnitPriceApproved { get; set; }
        public int? EnquiryDetailStatusId { get; set; }

        public virtual Enquire Enquiry { get; set; } = null!;
        public virtual Product? Product { get; set; }
    }
}
