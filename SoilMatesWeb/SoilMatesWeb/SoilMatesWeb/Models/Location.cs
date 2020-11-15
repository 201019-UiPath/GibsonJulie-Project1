using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SoilMatesWeb.Models
{
    public class Location
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public List<Inventory> StoreProducts { get; set; }
        public List<Order> OrderHistory { get; set; }
    }
}
