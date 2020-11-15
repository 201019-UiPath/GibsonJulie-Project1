using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SoilMatesWeb.Models
{
    public class OrderProduct
    {
        public int OrderForiegnId { get; set; }
        public int ProductForiegnId { get; set; }
        public Product Product { get; set; }
        public decimal Price { get; set; }
        public string Description { get; set; }
        public int Quantity { get; set; }
    }
}
