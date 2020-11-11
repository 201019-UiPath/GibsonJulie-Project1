using System;
using System.Collections.Generic;
using System.Text;

namespace SoilMatesResources.Models
{
    public class OrderProductResource
    {
        public ProductResource Product { get; set; }
        public OrderResource Order { get; set; }
        public int Quantity { get; set; }
    }
}
