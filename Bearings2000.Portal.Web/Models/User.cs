using System;
using System.Collections.Generic;

namespace Bearings2000.Portal.Web.Models
{
    public partial class User
    {
        public User()
        {
            Enquires = new HashSet<Enquire>();
            Orders = new HashSet<Order>();
        }

        public int UserId { get; set; }
        public string? AccountNumberRegistration { get; set; }
        public int? CustomerId { get; set; }
        public string EmailAddress { get; set; } = null!;
        public string? Password { get; set; }
        public string? FirstName { get; set; }
        public string? Surname { get; set; }
        public string? CellNumber { get; set; }
        public int? UserStatusId { get; set; }
        public DateTime? DateCreated { get; set; }
        public DateTime? DateProcessed { get; set; }
        public DateTime? DateLastLogin { get; set; }
        public string? Comment { get; set; }
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
        public Guid? UserIdentifier { get; set; }
        public string? UserPin { get; set; }
        public int? UserTypeId { get; set; }

        public virtual Customer? Customer { get; set; }
        public virtual UserStatus? UserStatus { get; set; }
        public virtual ICollection<Enquire> Enquires { get; set; }
        public virtual ICollection<Order> Orders { get; set; }
    }
}
