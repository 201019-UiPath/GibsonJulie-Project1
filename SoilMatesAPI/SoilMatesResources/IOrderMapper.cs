using SoilMatesResources.Models;
using System;
using System.Collections.Generic;
using System.Text;
using SoilMatesDB.Models;

namespace SoilMatesResources
{
    /// <summary>
    /// Maps Order model to Order resource model
    /// </summary>
    public interface IOrderMapper
    {
        Order ParseOrder(OrderResource order);
        OrderResource ParseOrder(Order order);
        List<OrderResource> ParseOrder(List<Order> order);

    }
}
