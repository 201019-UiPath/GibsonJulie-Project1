using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using SoilMatesWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace SoilMatesWeb.Controllers
{
    public class CustomerController : Controller
    {
        private readonly ILogger<CustomerController> _logger;
        private readonly IConfiguration _configuration;
        private readonly string apiBaseUrl;

        public CustomerController(ILogger<CustomerController> logger, IConfiguration configuration)
        {
            _logger = logger;
            _configuration = configuration;
            apiBaseUrl = _configuration.GetValue<string>("WebAPIBaseUrl");
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult PlaceOrder()
        {
            return View();
        }

        [HttpPost]
        public IActionResult PlaceOrder(int locationId)
        {
            var user = JsonConvert.DeserializeObject<User>(HttpContext.Session.GetString("SessionUser"));
            ShoppingCart cart = new ShoppingCart
            {
                UserId = user.Email,
                LocationId = locationId,
            };
            return RedirectToAction("StartOdering", "Customer", cart);
        }

       
        public IActionResult StartOdering(ShoppingCart cart)
        {
            return View(cart);
        }

        public IActionResult OrderHistory()
        {
            var user = JsonConvert.DeserializeObject<User>(HttpContext.Session.GetString("SessionUser"));
            User orderUser = new User { Email = user.Email };
            return View(orderUser);
        }

        public IActionResult ViewInventory()
        {
            return View();
        }

        [HttpPost]
        public IActionResult ViewInventory(int locationId)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(apiBaseUrl);
                var response = client.GetAsync($"Location/get/{locationId}");
                response.Wait();

                var result = response.Result;
                if (result.IsSuccessStatusCode)
                {
                    var jsonString = result.Content.ReadAsStringAsync();
                    jsonString.Wait();

                    var model = JsonConvert.DeserializeObject<Location>(jsonString.Result);
                    return View("ViewInventoryItems", model);
                }
            }
            return View();
        }
    }
}
