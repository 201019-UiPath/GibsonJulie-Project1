using System;
using System.Collections.Generic;
using System.Text;


namespace SoilMatesResources.Models
{
    public class LocationResource
    {
        
        //public int LocationId { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public List<InventoryResource> StoreProducts { get; set; }
        public List<OrderResource> orderHistory { get; set; }
    }
}
