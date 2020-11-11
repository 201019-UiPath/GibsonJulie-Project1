using SoilMatesDB.Models;
using SoilMatesResources.Models;
using System;
using System.Collections.Generic;

namespace SoilMatesResources
{
    public class Mapper : ICustomerMapper, IManagerMapper, IOrderMapper, IProductMapper, IOrderProductMapper
    {
        public Customer ParseCustomer(CustomerResource customer)
        {
            return new Customer()
            {
                Name = customer.Name,
                Email = customer.Email,
                Password = customer.Password
            };
        }

        public CustomerResource ParseCustomer(Customer customer)
        {
            return new CustomerResource()
            {
                Email = customer.Email,
                Name = customer.Name,
                Password = customer.Password,
            };
        }

        public List<CustomerResource> ParseCustomer(List<Customer> customer)
        {
            List<CustomerResource> allCustomers = new List<CustomerResource>();
            foreach(var c in customer)
            {
                allCustomers.Add(ParseCustomer(c));
            }
            return allCustomers;
        }

        public Manager ParseManager(ManagerResource manager)
        {
            return new Manager()
            {
                Name = manager.Name,
                Email = manager.Email,
                Password = manager.Password
            };
        }

        public ManagerResource ParseManager(Manager manager)
        {
            return new ManagerResource()
            {
                Name = manager.Name,
                Email = manager.Email,
                Password = manager.Password,
            };
        }

        public List<ManagerResource> ParseManager(List<Manager> manager)
        {
            List<ManagerResource> allManagers = new List<ManagerResource>();
            foreach (var m in manager)
            {
                allManagers.Add(ParseManager(m));
            }
            return allManagers;
        }

        public Order ParseOrder(OrderResource order)
        {
            return new Order
            {
                TotalPrice = order.TotalPrice,
                Address = order.Address,
                OrderTime = order.OrderTime,
                OrderId = order.OrderId,
                CustomerId = order.CustomerId,
                LocationId = order.LocationId,
                LineItem = ParseOrderProductResource(order.LineItem),
            };
        }

        public OrderResource ParseOrder(Order order)
        {
            return new OrderResource
            {
                TotalPrice = order.TotalPrice,
                Address = order.Address,
                OrderTime = order.OrderTime,
                OrderId = order.OrderId,
                CustomerId = order.CustomerId,
                LocationId = order.LocationId,
                LineItem = ParseOrderProductResource(order.LineItem)
            };
        }

        public List<OrderResource> ParseOrder(List<Order> order)
        {
            List<OrderResource> orderResources = new List<OrderResource>();
            foreach(var o in order)
            {
                orderResources.Add(ParseOrder(o));
            }
            return orderResources;
        }

        public Product ParseProduct(ProductResource product)
        {
            return new Product
            {
                Name = product.Name,
                Price = product.Price,
                Description = product.Description,
            };
        }

        public ProductResource ParseProduct(Product product)
        {
            return new ProductResource
            {
                Name = product.Name,
                Price = product.Price,
                Description = product.Description,
            };
        }

        public List<ProductResource> ParseProduct(List<Product> product)
        {
            List<ProductResource> products = new List<ProductResource>();
            foreach(var p in product)
            {
                products.Add(ParseProduct(p));
            }
            return products;
        }

        public OrderProduct ParseOrderProductResource(OrderProductResource orderProduct)
        {
            return new OrderProduct
            {
                ProductForiegnId= orderProduct.ProductForiegnId,
                OrderForiegnId = orderProduct.OrderForiegnId,
                Quantity = orderProduct.Quantity,
     
            };
        }

        public OrderProductResource ParseOrderProductResource(OrderProduct orderProduct)
        {
            return new OrderProductResource
            {
                OrderForiegnId =orderProduct.ProductForiegnId,
                ProductForiegnId = orderProduct.OrderForiegnId,
                Quantity = orderProduct.Quantity,
                Name = orderProduct.Product.Name,
                Price = orderProduct.Product.Price,
                Description = orderProduct.Product.Description,
            };
        }

        public List<OrderProductResource> ParseOrderProductResource(List<OrderProduct> orderProduct)
        {
            if (orderProduct != null)
            {
                List<OrderProductResource> orderProductResource = new List<OrderProductResource>();
                foreach (var op in orderProduct)
                {
                    orderProductResource.Add(ParseOrderProductResource(op));
                }

                return orderProductResource;
            }
            return null;
        }

        public List<OrderProduct> ParseOrderProductResource(List<OrderProductResource> orderProduct)
        {
            List<OrderProduct> orderProductResource = new List<OrderProduct>();
            foreach (var op in orderProduct)
            {
                orderProductResource.Add(ParseOrderProductResource(op));
            }
            return orderProductResource;
        }
    }
}
