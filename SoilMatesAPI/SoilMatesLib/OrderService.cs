using System;
using System.Runtime.CompilerServices;
using System.Collections.Generic;
using SoilMatesDB;
using SoilMatesDB.Models;

namespace SoilMatesLib
{
    /// <summary>
    /// Service for order models to interact with repository
    /// </summary>
    public class OrderService : IOrderService
    {
        private IOrdersRepo repo;

        /// <summary>
        /// Constructor with IRepository injection
        /// </summary>
        /// <param name="repo"></param>
        public OrderService(IRepository repo)
        {
            this.repo = repo;
        }

        public Customer GetCustomerByEmail(string email)
        {
            return repo.GetCustomerByEmail(email);
        }


        /// <summary>
        /// Add order to repository
        /// </summary>
        /// <param name="order"></param>
        public void AddOrder(Order order)
        {
            repo.AddOrder(order);
        }

        /// <summary>
        /// Get all orders from repository
        /// </summary>
        /// <returns></returns>
        public List<Order> GetAllOrders()
        {
            return repo.GetAllOrders();
        }

        /// <summary>
        /// Gets orders by customer id
        /// </summary>
        /// <param name="customerId"></param>
        /// <returns></returns>
        public List<Order> GetOrderByCustomerId(string email)
        {
            var customer = GetCustomerByEmail(email);
            List<Order> ordersForCustomer = new List<Order>();
            foreach (var item in repo.GetOrderByCustomerId(customer.Id))
            {
                if (item.CustomerId == customer.Id)
                {
                    ordersForCustomer.Add(item);
                }
            }
            return ordersForCustomer;

        }


        /// <summary>
        /// Gets order by location 
        /// </summary>
        /// <param name="locationId"></param>
        /// <returns></returns>
        public List<Order> GetOrderByLocatoinId(int locationId)
        {
            List<Order> ordersForCustomer = new List<Order>();
            foreach (var item in repo.GetOrderByLocationId(locationId))
            {
                if (item.LocationId == locationId)
                {
                    ordersForCustomer.Add(item);
                }
            }
            return ordersForCustomer;
        }

        /// <summary>
        /// Submits order once customer is done adding items 
        /// </summary>
        /// <param name="newOrder"></param>
        /// <param name="customerId"></param>
        /// <param name="storeId"></param>
        /// <param name="totalPrice"></param>
        public void SubmitOrder(Order newOrder, int customerId, int storeId, decimal totalPrice)
        {
            newOrder.OrderTime = DateTime.Now;
            newOrder.CustomerId = customerId;
            newOrder.LocationId = storeId;
            newOrder.TotalPrice = totalPrice;
        }

        /// <summary>
        /// Saves changes to repository
        /// </summary>
        public void SaveChanges()
        {
            repo.SaveChanges();
        }

    }
}