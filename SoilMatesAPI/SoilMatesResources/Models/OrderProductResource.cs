﻿using System;
using System.Collections.Generic;
using System.Text;

namespace SoilMatesResources.Models
{
    /// <summary>
    /// Web Order Product resource
    /// </summary>
    public class OrderProductResource
    {
        public int OrderForiegnId { get; set; }
        public int ProductForiegnId { get; set; }
        public ProductResource Product { get; set; }
        public decimal Price { get; set; }
        public string Description { get; set; }
        public int Quantity { get; set; }
    }
}
