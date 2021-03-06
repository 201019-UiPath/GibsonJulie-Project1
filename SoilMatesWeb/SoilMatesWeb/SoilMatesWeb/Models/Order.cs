﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SoilMatesWeb.Models
{
    public class Order
    {
        public int OrderId { get; set; }
        public int CustomerId { get; set; }
        public int LocationId { get; set; }
        public string Address { get; set; }
        public DateTime OrderTime { get; set; }
        public Decimal TotalPrice { get; set; }
        public List<OrderProduct> LineItem { get; set; } 
    }
}
