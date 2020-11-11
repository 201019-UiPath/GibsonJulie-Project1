using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SoilMatesResources.Models
{
    public class OrderResource
    {
        public string Address { get; set; }
        public DateTime OrderTime { get; set; }
        public Decimal TotalPrice { get; set; }
        public List<OrderProductResource> LineItem { get; set; }
    }
}
