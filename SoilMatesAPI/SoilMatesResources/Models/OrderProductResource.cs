using System;
using System.Collections.Generic;
using System.Text;

namespace SoilMatesResources.Models
{
    public class OrderProductResource
    {
        public int OrderForiegnId { get; set; }
        public int ProductForiegnId { get; set; }
        public String Name { get; set; }
        public decimal Price { get; set; }
        public string Description { get; set; }
        public int Quantity { get; set; }
    }
}
