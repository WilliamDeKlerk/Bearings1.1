using System;
using System.Collections.Generic;

namespace Bearings2000.Portal.Web.Models
{
    public partial class VEnquiryList
    {
        public int EquiryId { get; set; }
        public int? UserId { get; set; }
        public int? CustomerId { get; set; }
        public DateTime? EnquiryCreatedDate { get; set; }
        public DateTime? EnquiryProcessedDate { get; set; }
        public int? EnquiryStatusId { get; set; }
        public string? Comment { get; set; }
        public int IsProcessed { get; set; }
        public string? FirstName { get; set; }
        public string? Surname { get; set; }
        public string? FullName { get; set; }
        public string? AccountNumber { get; set; }
        public string? CustomerName { get; set; }
    }
}
