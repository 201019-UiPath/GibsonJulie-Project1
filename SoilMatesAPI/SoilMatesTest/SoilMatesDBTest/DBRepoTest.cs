using System;
using System.Reflection;
using Xunit;
using SoilMatesDB.Models;
using SoilMatesDB;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.InMemory;

namespace SoilMatesTest.SoilMatesDBTest
{
    /// <summary>
    /// Test database methods
    /// </summary>
    public class DBRepoTest
    {
        private DBrepo repo;

        private readonly Customer testCustomer = new Customer()
        {
            Id = 1,
            UserType = 0,
            Name = "Shadow",
            Email = "ShadowIncLLC@gmail.com",
            Password = "woofwoof"
        };

        private readonly Manager testManager = new Manager()
        {
            Id = 1,
            UserType = 1,
            Name = "Karen",
            Email = "KarensWW@gmail.com",
            Password = "password"
        };

        private readonly Inventory testInventory = new Inventory()
        {
            InventoryId = 0,
            ProductForeingId = 1,
            LocationForeignId = 1,
        };

        private readonly List<Inventory> testInventories = new List<Inventory>() {
             new Inventory() {
                 InventoryId = 1,
                 ProductForeingId = 2,
                 LocationForeignId =2,
             },
             new Inventory() {
                  InventoryId = 5,
                 ProductForeingId = 6,
                 LocationForeignId =7,
             }
         };

        private readonly Location testLocation = new Location()
        {
            LocationId = 0,
            Name = "TreeMates",
            Address = "Tampa, FL",
        };

        private readonly Order testOrder = new Order()
        {
            OrderId = 1,
            CustomerId = 1,
            LocationId = 1,
            Address = "Sebring, Fl",
            OrderTime = DateTime.Now,
            TotalPrice = 2.00m,
        };

        private readonly List<Order> testOrders = new List<Order>()
        {
            new Order()
            {
                 OrderId = 1,
                CustomerId = 1,
                LocationId = 1,
                Address = "Sebring, Fl",
                OrderTime = DateTime.Now,
                TotalPrice = 2.00m,
            },
            new Order()
            {
                 OrderId = 2,
                CustomerId = 2,
                LocationId = 2,
                Address = "Sebring, Fl",
                OrderTime = DateTime.Now,
                TotalPrice = 2.00m,
            }

        };



        private readonly OrderProduct testOrderProduct = new OrderProduct()
        {
            Id = 2,
            OrderForiegnId = 3,
            ProductForiegnId = 1,
        };

        private readonly List<OrderProduct> testOrderProducts = new List<OrderProduct>()
        {
            new OrderProduct
            {
                 Id = 2,
                OrderForiegnId = 3,
                ProductForiegnId = 1,
            },
             new OrderProduct
            {
                 Id = 3,
                OrderForiegnId = 5,
                ProductForiegnId = 6,
            },

        };

        private readonly Product testProduct = new Product()
        {
            ProductId = 2,
            Description = "Edible",
            Name = "BlueBerry",
            Price = 3.00m,
        };

        private readonly List<Product> testProducts = new List<Product>(){
             new Product(){
                 ProductId = 6,
                 Description = "Succulent",
                 Name = "Aloe",
                 Price = 2.00m,
             },
             new Product(){
                 ProductId = 3,
                 Description = "Edible",
                 Name = "Mango Tree",
                 Price = 20.00m,
             }
         };

        private readonly List<Location> testLocations = new List<Location>(){
             new Location (){
                 LocationId = 3,
                 Name = "FlowerMates",
                 Address = "Tampa, FL",
             },
             new Location (){
                 LocationId = 1,
                 Name = "EdibleMates",
                 Address = "Dallas, TX",
             }
         };

        private readonly List<Customer> testCustomers = new List<Customer>(){
            new Customer(){
                Id = 2,
                UserType = 0,
                Name = "Eric",
                Email = "EricTheElectric@mail.usf.edu",
                Password = "WOWmoment"
            },
            new Customer() {
                 Id = 3,
                UserType = 0,
                Name = "Will",
                Email = "OllieAndWill@mail.com",
                Password = "BostonCream",
            },
        };


        private readonly List<Manager> testManagers = new List<Manager>(){
            new Manager(){
                Id = 4,
                UserType = 1,
                Name = "Babish",
                Email = "Binging@mail.usf.edu",
                Password = "Basics"
            },
            new Manager() {
                 Id = 5,
                UserType = 0,
                Name = "Schitt",
                Email = "ShittsCreek@mail.com",
                Password = "AlittleBitAlexis",
            },
        };


        private void seed(SoilMatesContext testcontext)
        {
            testcontext.Customers.AddRange(testCustomers);
            testcontext.Managers.AddRange(testManagers);
            testcontext.Inventories.AddRange(testInventories);
            testcontext.Locations.AddRange(testLocations);
            testcontext.Products.AddRange(testProducts);
            testcontext.OrderProducts.AddRange(testOrderProducts);
            testcontext.Orders.AddRange(testOrders);
            testcontext.SaveChanges();
        }


        /// <summary>
        /// Tests if customer is added to repository correctly
        /// </summary>
        [Fact]
        public void AddCustomerShouldAdd()
        {
            //arrange
            var options = new DbContextOptionsBuilder<SoilMatesContext>().UseInMemoryDatabase("AddCustomerShouldAdd").Options;
            using var testContext = new SoilMatesContext(options);
            repo = new DBrepo(testContext);

            //act
            repo.AddCustomer(testCustomer);

            //assert
            using var assertContext = new SoilMatesContext(options);
            Assert.NotNull(assertContext.Customers.SingleAsync(n => n.Name == testCustomer.Name));
        }

        /// <summary>
        /// Test if manager is added to repository
        /// </summary>
        [Fact]
        public void AddManagerShouldAdd()
        {
            //arrange
            var options = new DbContextOptionsBuilder<SoilMatesContext>().UseInMemoryDatabase("AddManagerShouldAdd").Options;
            using var testContext = new SoilMatesContext(options);
            repo = new DBrepo(testContext);

            //act
            repo.AddManager(testManager);

            //assert
            using var assertContext = new SoilMatesContext(options);
            Assert.NotNull(assertContext.Managers.SingleAsync(n => n.Name == testManager.Name));
        }

        /// <summary>
        /// Test if inventory is added to repository correctly
        /// </summary>
        [Fact]
        public void AddInventoryShouldAdd()
        {
            //arrange
            var options = new DbContextOptionsBuilder<SoilMatesContext>().UseInMemoryDatabase("AddInventoryShoudAdd").Options;
            using var testContext = new SoilMatesContext(options);
            repo = new DBrepo(testContext);

            //act
            repo.AddInventory(testInventory);

            //assert
            using var assertContext = new SoilMatesContext(options);
            Assert.NotNull(assertContext.Inventories.SingleAsync(n => n.InventoryId == testInventory.InventoryId));
        }

        /// <summary>
        /// Test if location is added to repository
        /// </summary>
        [Fact]
        public void AddLocationShouldAdd()
        {
            //arrange
            var options = new DbContextOptionsBuilder<SoilMatesContext>().UseInMemoryDatabase("AddLocationShoudAdd").Options;
            using var testContext = new SoilMatesContext(options);
            repo = new DBrepo(testContext);

            //act
            repo.AddLocation(testLocation);

            //assert
            using var assertContext = new SoilMatesContext(options);
            Assert.NotNull(assertContext.Inventories.SingleAsync(n => n.InventoryId == testInventory.InventoryId));
        }

        /// <summary>
        /// Test if order is added to repository
        /// </summary>
        [Fact]
        public void AddOrderShouldAdd()
        {
            //arrange
            var options = new DbContextOptionsBuilder<SoilMatesContext>().UseInMemoryDatabase("AddOrderShoudAdd").Options;
            using var testContext = new SoilMatesContext(options);
            repo = new DBrepo(testContext);

            //act
            repo.AddOrder(testOrder);

            //assert
            using var assertContext = new SoilMatesContext(options);
            Assert.NotNull(assertContext.Orders.SingleAsync(n => n.OrderId == testOrder.OrderId));
        }

        /// <summary>
        /// Test if add OrderProduct is added to repository
        /// </summary>
        [Fact]
        public void AddOrderProductShouldAdd()
        {
            //arrange
            var options = new DbContextOptionsBuilder<SoilMatesContext>().UseInMemoryDatabase("AddOrderProductShoudAdd").Options;
            using var testContext = new SoilMatesContext(options);
            repo = new DBrepo(testContext);

            //act
            repo.AddOrderProduct(testOrderProduct);

            //assert
            using var assertContext = new SoilMatesContext(options);
            Assert.NotNull(assertContext.OrderProducts.SingleAsync(n => n.Id == testOrderProduct.Id));
        }

        /// <summary>
        /// Test if Product is added to repository
        /// </summary>
        [Fact]
        public void AddProductShouldAdd()
        {
            //arrange
            var options = new DbContextOptionsBuilder<SoilMatesContext>().UseInMemoryDatabase("AddProductShoudAdd").Options;
            using var testContext = new SoilMatesContext(options);
            repo = new DBrepo(testContext);

            //act
            repo.AddProduct(testProduct);

            //assert
            using var assertContext = new SoilMatesContext(options);
            Assert.NotNull(assertContext.Products.SingleAsync(n => n.Name == testProduct.Name));
        }

        /// <summary>
        /// Test if GetCustomer method returns customer by id
        /// </summary>
        [Fact]
        public void GetCustomerShouldGet()
        {
            var options = new DbContextOptionsBuilder<SoilMatesContext>().UseInMemoryDatabase("GetCustomerShouldGet").Options;
            using var testContext = new SoilMatesContext(options);
            seed(testContext);

            using var assertContext = new SoilMatesContext(options);
            repo = new DBrepo(assertContext);

            var result = repo.GetCustomer(3);

            Assert.NotNull(result);
            Assert.Equal("Will", result.Name);
        }

        [Fact]
        public void GetLocationByIdShouldGet()
        {

            var options = new DbContextOptionsBuilder<SoilMatesContext>().UseInMemoryDatabase("GetLocationByIdShouldGet").Options;
            using var testContext = new SoilMatesContext(options);
            seed(testContext);

            using var assertContext = new SoilMatesContext(options);
            repo = new DBrepo(assertContext);

            var result = repo.GetLocationById(3);

            Assert.NotNull(result);
            Assert.Equal("FlowerMates", result.Name);
        }


        /// <summary>
        /// test if customer is retrieved by login
        /// </summary>
        [Fact]
        public void GetCustomerByLoginShouldGet()
        {
            var options = new DbContextOptionsBuilder<SoilMatesContext>().UseInMemoryDatabase("GetCustomerByLoginShouldGet").Options;
            using var testContext = new SoilMatesContext(options);
            seed(testContext);

            using var assertContext = new SoilMatesContext(options);
            repo = new DBrepo(assertContext);

            var result = repo.GetCustomerByLogin("BostonCream", "OllieAndWill@mail.com");

            Assert.NotNull(result);
            Assert.Equal("Will", result.Name);
        }

        [Fact]
        public void GetCustomerByEmailShouldGet()
        {
            var options = new DbContextOptionsBuilder<SoilMatesContext>().UseInMemoryDatabase("GetCustomerByEmailShouldGet").Options;
            using var testContext = new SoilMatesContext(options);
            seed(testContext);

            using var assertContext = new SoilMatesContext(options);
            repo = new DBrepo(assertContext);

            var result = repo.GetCustomerByEmail("OllieAndWill@mail.com");

            Assert.NotNull(result);
            Assert.Equal("Will", result.Name);
        }


        /// <summary>
        /// Tests if manager is retrieved by emil
        /// </summary>
        [Fact]
        public void GetManagerByEmailShouldGet()
        {
            var options = new DbContextOptionsBuilder<SoilMatesContext>().UseInMemoryDatabase("GetManagerByEmailShouldGet").Options;
            using var testContext = new SoilMatesContext(options);
            seed(testContext);

            using var assertContext = new SoilMatesContext(options);
            repo = new DBrepo(assertContext);

            var result = repo.GetManagerByEmail("Binging@mail.usf.edu");

            Assert.NotNull(result);
            Assert.Equal("Babish", result.Name);
        }



        /// <summary>
        /// Test if manager can be retrieved by manager id
        /// </summary>
        [Fact]
        public void GetManagerShouldGet()
        {
            var options = new DbContextOptionsBuilder<SoilMatesContext>().UseInMemoryDatabase("GetManagerShouldGet").Options;
            using var testContext = new SoilMatesContext(options);
            seed(testContext);

            using var assertContext = new SoilMatesContext(options);
            repo = new DBrepo(assertContext);

            var result = repo.GetManagerById(4);

            Assert.NotNull(result);
            Assert.Equal("Babish", result.Name);
        }

        /// <summary>
        /// Test if product can be retrieved from repository by product id
        /// </summary>
        [Fact]
        public void GetProductShouldGet()
        {
            var options = new DbContextOptionsBuilder<SoilMatesContext>().UseInMemoryDatabase("GetProductShouldGet").Options;
            using var testContext = new SoilMatesContext(options);
            seed(testContext);

            using var assertContext = new SoilMatesContext(options);
            repo = new DBrepo(assertContext);

            var result = repo.GetProduct(6);

            Assert.NotNull(result);
            Assert.Equal("Aloe", result.Name);
        }

        

        /// <summary>
        /// Test if product can be retrieved from repository by product id
        /// </summary>
        [Fact]
        public void GetProductByNameShouldGet()
        {
            var options = new DbContextOptionsBuilder<SoilMatesContext>().UseInMemoryDatabase("GetProductByNameShouldGet").Options;
            using var testContext = new SoilMatesContext(options);
            seed(testContext);

            using var assertContext = new SoilMatesContext(options);
            repo = new DBrepo(assertContext);

            var result = repo.GetProduct("Aloe");

            Assert.NotNull(result);
            Assert.Equal("Aloe", result.Name);
        }

        /// <summary>
        /// Test if gets all locations
        /// </summary>
        [Fact]
        public void GetALLLocationsShouldGet()
        {
            var options = new DbContextOptionsBuilder<SoilMatesContext>().UseInMemoryDatabase("GetAllLocationsShouldGet").Options;
            using var testContext = new SoilMatesContext(options);
            seed(testContext);

            using var assertContext = new SoilMatesContext(options);
            repo = new DBrepo(assertContext);

            var result = repo.GetAllLocations();

            Assert.NotNull(result);
            Assert.Equal(2,result.Count);
        }

        /// <summary>
        /// Get all products should get all products 
        /// </summary>
        [Fact]
        public void GetALLProductsShouldGet()
        {
            var options = new DbContextOptionsBuilder<SoilMatesContext>().UseInMemoryDatabase("GetAllProductsShouldGet").Options;
            using var testContext = new SoilMatesContext(options);
            seed(testContext);

            using var assertContext = new SoilMatesContext(options);
            repo = new DBrepo(assertContext);

            var result = repo.GetAllProducts();

            Assert.NotNull(result);
            Assert.Equal(2, result.Count);
        }

        /// <summary>
        /// Get all order products should get
        /// </summary>
        [Fact]
        public void GetALLOrderProductsShouldGet()
        {
            var options = new DbContextOptionsBuilder<SoilMatesContext>().UseInMemoryDatabase("GetAllOrderProductsShouldGet").Options;
            using var testContext = new SoilMatesContext(options);
            seed(testContext);

            using var assertContext = new SoilMatesContext(options);
            repo = new DBrepo(assertContext);

            var result = repo.GetAllOrderProduct();

            Assert.NotNull(result);
            Assert.Equal(2, result.Count);
        }

        /// <summary>
        /// Get all order should get all orders
        /// </summary>
        [Fact]
        public void GetALLOrdersProductsShouldGet()
        {
            var options = new DbContextOptionsBuilder<SoilMatesContext>().UseInMemoryDatabase("GetAllOrderShouldGet").Options;
            using var testContext = new SoilMatesContext(options);
            seed(testContext);

            using var assertContext = new SoilMatesContext(options);
            repo = new DBrepo(assertContext);

            var result = repo.GetAllOrders();

            Assert.NotNull(result);
            Assert.Equal(2, result.Count);
        }

        /// <summary>
        /// Get all order products should get
        /// </summary>
        [Fact]
        public void GetALLManagersProductsShouldGet()
        {
            var options = new DbContextOptionsBuilder<SoilMatesContext>().UseInMemoryDatabase("GetAllManagersGet").Options;
            using var testContext = new SoilMatesContext(options);
            seed(testContext);

            using var assertContext = new SoilMatesContext(options);
            repo = new DBrepo(assertContext);

            var result = repo.GetAllManagers();

            Assert.NotNull(result);
            Assert.Equal(2, result.Count);
        }

  

    }
}