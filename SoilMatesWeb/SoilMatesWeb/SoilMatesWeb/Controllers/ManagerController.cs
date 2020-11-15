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
using System.Threading.Tasks;

namespace SoilMatesWeb.Controllers
{
    public class ManagerController : Controller
    {
        private readonly ILogger<ManagerController> _logger;
        private readonly IConfiguration _configuration;
        private readonly string apiBaseUrl;

        public ManagerController(ILogger<ManagerController> logger, IConfiguration configuration)
        {
            _logger = logger;
            _configuration = configuration;
            apiBaseUrl = _configuration.GetValue<string>("WebAPIBaseUrl");
        }

        public IActionResult Index()
        {
            var sessionUser = JsonConvert.DeserializeObject<User>(HttpContext.Session.GetString("SessionUser"));
            return View();
        }

        public IActionResult ViewAllLocations()
        {
            return View();
        }

        public IActionResult ViewOrdersByLocation()
        {
            return View();
        }


        [HttpPost]
        public IActionResult ViewOrdersByLocation(int locationId)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(apiBaseUrl);
                var response = client.GetAsync($"Order/get/Location/{locationId}");
                response.Wait();

                var result = response.Result;
                if (result.IsSuccessStatusCode)
                {
                    var jsonString = result.Content.ReadAsStringAsync();
                    jsonString.Wait();

                    var model = JsonConvert.DeserializeObject<IEnumerable<Order>>(jsonString.Result);
                    return View("ViewOrdersAtLocation", model);
                }
            }
            return View();
        }

        public IActionResult AddProduct()
        {
            return View();
        }

        public IActionResult GetInventory()
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

        public IActionResult ReplenishInventory()
        {
            return View();
        }
    }
}

