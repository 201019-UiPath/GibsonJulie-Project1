using SoilMatesDB.Models;
using SoilMatesResources.Models;
using System;
using System.Collections.Generic;
using SoilMatesLib;

namespace SoilMatesResources
{
    public class Mapper : ICustomerMapper, IManagerMapper, IOrderMapper, IProductMapper, IOrderProductMapper, ILocationMapper, IInventoryMapper
    {
        public Customer ParseCustomer(CustomerResource customer)
        {
            return new Customer()
            {
                //UserType = customer.UserType,
                Name = customer.Name,
                Email = customer.Email,
                Password = customer.Password
            };
        }

        public CustomerResource ParseCustomer(Customer customer)
        {
            return new CustomerResource()
            {
                Id = customer.Id,
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
                Product = ParseProduct(orderProduct.Product),
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
            if (orderProduct != null)
            {
                List<OrderProduct> orderProductResource = new List<OrderProduct>();
                foreach (var op in orderProduct)
                {
                    orderProductResource.Add(ParseOrderProductResource(op));
                }
                return orderProductResource;
            }
            return null;
        }

        public Location ParseLocation(LocationResource location)
        {
            return new Location
            {
                LocationId = location.LocationId,
                Name = location.Name,
                Address = location.Address,
                StoreProducts = ParseInventory(location.StoreProducts),
                //add parse inventory 
                //order history
            };
        }

        public LocationResource ParseLocation(Location location)
        {
            return new LocationResource
            {
                LocationId = location.LocationId,
                Name = location.Name,
                Address = location.Address,
                StoreProducts = ParseInventory(location.StoreProducts),
                //parse inventory
                //order history?
            };
        }

        public List<LocationResource> ParseLocation(List<Location> location)
        {
            if (location != null)
            {
                List<LocationResource> locationResource = new List<LocationResource>();
                foreach (var loc in location)
                {
                    locationResource.Add(ParseLocation(loc));
                }
                return locationResource;
            }
            return null;
        }

        public List<Location> ParseLocation(List<LocationResource> location)
        {
            if (location != null)
            {
                List<Location> locations = new List<Location>();
                foreach (var loc in location)
                {
                    locations.Add(ParseLocation(loc));
                }
                return locations;
            }
            return null;
        }
        
        public Inventory ParseInventory(InventoryResource inventory)
        {
            return new Inventory
            {
                InventoryId = inventory.InventoryId,
                Quantity = inventory.Quantity,
                ProductForeingId = inventory.ProductForeingId,
                LocationForeignId = inventory.LocationForeignId,
                Product = ParseProduct(inventory.Product),
            };
        }

        public InventoryResource ParseInventory(Inventory inventory)
        {
            return new InventoryResource
            {
                InventoryId = inventory.InventoryId,
                Quantity = inventory.Quantity,
                ProductForeingId = inventory.ProductForeingId,
                LocationForeignId = inventory.LocationForeignId,
                Product = ParseProduct(inventory.Product),
            };
        }

        public List<InventoryResource> ParseInventory(List<Inventory> inventory)
        {
            if (inventory != null)
            {
                List<InventoryResource> inventories = new List<InventoryResource>();
                foreach (var inv in inventory)
                {
                    inventories.Add(ParseInventory(inv));
                }
                return inventories;
            }
            return null;

        }

        public List<Inventory> ParseInventory(List<InventoryResource> inventory)
        {
            if (inventory != null)
            {
                List<Inventory> inventories = new List<Inventory>();
                foreach (var inv in inventory)
                {
                    inventories.Add(ParseInventory(inv));
                }
                return inventories;
            }
            return null;
        }
    }
}
