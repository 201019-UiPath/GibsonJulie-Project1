using System;
using System.Collections.Generic;
using System.Text;

namespace SoilMatesResources.Models
{
    public class ProductResource
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
        public List<InventoryResource> ProductLocations { get; set; }
        public List<OrderProductResource> LineItem { get; set; }
    }
}
