using System;
using System.Collections.Generic;

namespace Bearings2000.Portal.Web.Models
{
    public partial class Customer
    {
        public Customer()
        {
            Enquires = new HashSet<Enquire>();
            Orders = new HashSet<Order>();
            Users = new HashSet<User>();
        }

        public int CustomerId { get; set; }
        public string? CustomerName { get; set; }
        public string? AccountNumber { get; set; }
        public DateTime? DateCreated { get; set; }
        public bool? Active { get; set; }
        public bool? CanCreateEnquiry { get; set; }
        public bool? CanViewDocuments { get; set; }
        public bool? CanViewTracking { get; set; }
        public bool? IndividualPricing { get; set; }
        public bool? CustomerPricing { get; set; }
        public bool? ShowPrice { get; set; }
        public bool? ShowActualQuantity { get; set; }
        public bool? ShowNoQuantity { get; set; }
        public bool? ShowHighlevelQuantity { get; set; }
        public bool? ShowMaxAllowedToViewQuantity { get; set; }

        public virtual ICollection<Enquire> Enquires { get; set; }
        public virtual ICollection<Order> Orders { get; set; }
        public virtual ICollection<User> Users { get; set; }
    }
}
