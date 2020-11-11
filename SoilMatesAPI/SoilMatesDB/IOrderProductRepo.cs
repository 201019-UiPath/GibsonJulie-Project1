using System.Collections.Generic;
using SoilMatesDB.Models;
namespace SoilMatesDB
{
    /// <summary>
    /// Interface for OrderProduct repository
    /// </summary>
    public interface IOrderProductRepo
    {
        List<OrderProduct> GetAllOrderProduct();
        void AddOrderProduct(OrderProduct lineItem);
        OrderProduct GetOrderProduct(int orderId, int productId);
    }
}