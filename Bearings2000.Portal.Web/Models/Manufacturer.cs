using System;
using System.Collections.Generic;

namespace Bearings2000.Portal.Web.Models
{
    public partial class Manufacturer
    {
        public Manufacturer()
        {
            Products = new HashSet<Product>();
        }

        public int ManufacturerId { get; set; }
        public string? Manufacturer1 { get; set; }
        public byte[]? ManufacturerImage { get; set; }
        public bool? Active { get; set; }

        public virtual ICollection<Product> Products { get; set; }
    }
}
