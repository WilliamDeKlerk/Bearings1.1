using System;
using System.Collections.Generic;

namespace Bearings2000.Portal.Web.Models
{
    public partial class VOrderList
    {
        public int OrderId { get; set; }
        public int? UserId { get; set; }
        public int? CustomerId { get; set; }
        public DateTime? OrderCreatedDate { get; set; }
        public DateTime? OrderProcessedDate { get; set; }
        public int? OrderStatusId { get; set; }
        public string? Comment { get; set; }
        public string? DocumentPath { get; set; }
        public string? FirstName { get; set; }
        public string? Surname { get; set; }
        public string? FullName { get; set; }
        public string? AccountNumber { get; set; }
        public string? CustomerName { get; set; }
        public string? InvoiceName { get; set; }
    }
}
