using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SoilMatesWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SoilMatesWeb.Controllers
{
    public class ManagerController : Controller
    {
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

        public IActionResult AddProduct()
        {
            return View();
        }

        public IActionResult GetInventory()
        {
            return View();
        }
    }
}
