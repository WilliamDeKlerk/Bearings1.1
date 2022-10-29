using System;
using System.Collections.Generic;

namespace Bearings2000.Portal.Web.Models
{
    public partial class ProductType
    {
        public ProductType()
        {
            Products = new HashSet<Product>();
        }

        public int ProductTypeId { get; set; }
        public string? ProductType1 { get; set; }
        public string? ProductTypeDescription { get; set; }
        public byte[]? ProductTypeImage { get; set; }
        public bool? Active { get; set; }

        public virtual ICollection<Product> Products { get; set; }
    }
}
