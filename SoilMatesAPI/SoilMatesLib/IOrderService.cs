using SoilMatesDB.Models;
using System.Collections.Generic;

namespace SoilMatesLib
{
    public interface IOrderService
    {
        void AddOrder(Order order);
        List<Order> GetAllOrders();
        List<Order> GetOrderByCustomerId(int customerId);
        List<Order> GetOrderByLocatoinId(int locationId);
        void SaveChanges();
        void SubmitOrder(Order newOrder, int customerId, int storeId, decimal totalPrice);
    }
}