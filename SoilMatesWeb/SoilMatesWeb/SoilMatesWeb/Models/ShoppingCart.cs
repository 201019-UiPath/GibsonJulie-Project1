using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SoilMatesWeb.Models
{
    public class ShoppingCart
    {
        public List<Product> Items { get; set; }
        public string UserId {get; set;}
        public int LocationId { get; set; }
    }
}
