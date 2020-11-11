using System;
using System.Collections.Generic;
using System.Text;

namespace SoilMatesResources.Models
{
    public class InventoryResource
    {
        public int InventoryId { get; set; }
        public int Quantity { get; set; }
        public int ProductForeingId { get; set; }
        public ProductResource Product { get; set; }
        public int LocationForeignId { get; set; }
        public LocationResource Location { get; set; }

    }
}
