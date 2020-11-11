using SoilMatesDB.Models;
using System.Collections.Generic;

namespace SoilMatesLib
{
    public interface IOrderProductService
    {
        void AddOrderProduct(OrderProduct orderProduct);
        List<OrderProduct> GetAllOrderProduct();
        OrderProduct GetOrderProduct(int orderId, int productId);
        void UpdateOrderProductInCart(OrderProduct itemInCart, Product soldProduct, Order newOrder);
    }
}