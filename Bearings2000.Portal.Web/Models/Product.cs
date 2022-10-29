using System;
using System.Collections.Generic;

namespace Bearings2000.Portal.Web.Models
{
    public partial class Product
    {
        public Product()
        {
            EnquiryDetails = new HashSet<EnquiryDetail>();
            OrderDetails = new HashSet<OrderDetail>();
        }

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
        public decimal? DiscountPerc { get; set; }
        public decimal? QuotedPrice { get; set; }

        public virtual Manufacturer? ProductManufacturer { get; set; }
        public virtual ProductType? ProductType { get; set; }
        public virtual ICollection<EnquiryDetail> EnquiryDetails { get; set; }
        public virtual ICollection<OrderDetail> OrderDetails { get; set; }
    }
}
