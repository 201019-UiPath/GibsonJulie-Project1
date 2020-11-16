using SoilMatesDB.Models;
using SoilMatesResources.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace SoilMatesResources
{
    /// <summary>
    /// Maps OrderProduct from web and data models
    /// </summary>
    public interface IOrderProductMapper
    {
        OrderProduct ParseOrderProductResource(OrderProductResource orderProduct);
        OrderProductResource ParseOrderProductResource(OrderProduct orderProduct);
        List<OrderProductResource> ParseOrderProductResource(List<OrderProduct> orderProduct);

        List<OrderProduct> ParseOrderProductResource(List<OrderProductResource> orderProduct);
    }
}
