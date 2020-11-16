using System;
using System.Collections.Generic;
using System.Text;

namespace SoilMatesResources.Models
{
    /// <summary>
    /// Product resource
    /// </summary>
    public class ProductResource
    {
        public int ProductId { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string Description { get; set; }
    }
}
