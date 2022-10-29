using System;
using System.Collections.Generic;

namespace Bearings2000.Portal.Web.Models
{
    public partial class VEnquiryDetailList
    {
        public int EquiryId { get; set; }
        public int? UserId { get; set; }
        public int? CustomerId { get; set; }
        public DateTime? EnquiryCreatedDate { get; set; }
        public DateTime? EnquiryProcessedDate { get; set; }
        public int? EnquiryStatusId { get; set; }
        public string? Comment { get; set; }
        public int EnquiryDetailId { get; set; }
        public int? EnquiryDetailStatusId { get; set; }
        public int? QuantityRequested { get; set; }
        public int? QuanityApproved { get; set; }
        public decimal? UnitPriceRequested { get; set; }
        public decimal? UnitPriceApproved { get; set; }
        public int ProductId { get; set; }
        public int? ProductTypeId { get; set; }
        public int? ProductManufacturerId { get; set; }
        public string? ProductCode { get; set; }
        public string? ProductName { get; set; }
        public string? ProductDescription { get; set; }
        public int? ProductEconomicallyViableQuantity { get; set; }
        public int? ProductMaxQuantity { get; set; }
        public int? ProductAvailableQuantity { get; set; }
        public int? ProductReservedQuantity { get; set; }
        public DateTime? LastAvailableDateTimeStamp { get; set; }
        public bool? ShowPriceOverride { get; set; }
        public bool? ShowQuantityOverride { get; set; }
        public bool? ShowMaxQuantityOverride { get; set; }
        public byte[]? ProductImage { get; set; }
        public bool? Active { get; set; }
        public string? ProductType { get; set; }
        public string? ProductTypeDescription { get; set; }
        public string? Manufacturer { get; set; }
        public string? FirstName { get; set; }
        public string? Surname { get; set; }
        public string? FullName { get; set; }
        public string? AccountNumber { get; set; }
        public string? CustomerName { get; set; }
    }
}
