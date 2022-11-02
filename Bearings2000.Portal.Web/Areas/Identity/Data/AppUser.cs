using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using Bearings2000.Portal.Web.Models;
using Microsoft.AspNetCore.Identity;

namespace Bearings2000.Portal.Web.Areas.Identity.Data
{
    public class AppUser : IdentityUser
    {
        public string? AccountNumberRegistration { get; set; }



        public string? FirstName { get; set; }
        public string? Surname { get; set; }
        public string? CellNumber { get; set; }

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
        

        public int?   CustomerId { get; set; }

        public  int? UserStatusId { get; set; }
      
    }
}
