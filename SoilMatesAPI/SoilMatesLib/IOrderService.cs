using SoilMatesDB.Models;
using System.Collections.Generic;

namespace SoilMatesLib
{
    /// <summary>
    /// Order service interface
    /// </summary>
    public interface IOrderService
    {
        Customer GetCustomerByEmail(string email);
        void AddOrder(Order order);
        List<Order> GetAllOrders();
        List<Order> GetOrderByCustomerId(string email);
        List<Order> GetOrderByLocatoinId(int locationId);
        void SaveChanges();
        void SubmitOrder(Order newOrder, int customerId, int storeId, decimal totalPrice);
    }
}