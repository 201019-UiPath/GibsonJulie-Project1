using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using SoilMatesWeb.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Http;


namespace SoilMatesWeb.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IConfiguration _configuration;
        private readonly string apiBaseUrl;
        private User loggedIn;

        public HomeController(ILogger<HomeController> logger, IConfiguration configuration)
        {
            _logger = logger;
            _configuration = configuration;

            apiBaseUrl = _configuration.GetValue<string>("WebAPIBaseUrl");
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult AboutUs()
        {
            return View();
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(User user)
        {  
            if(user != null)
            {
                HttpContext.Session.SetString("SessionUser", JsonConvert.SerializeObject(user));
                return RedirectToAction("Index", "Manager", user);
            }
            return RedirectToAction("Index", "Home");
        }

        public IActionResult SignUp()
        {
            return View();
        }

        public IActionResult CustomerLogin()
        {
            return View();
        }


        [HttpPost]
        public IActionResult CustomerLogin(User user)
        {
            if (user != null)
            {
                HttpContext.Session.SetString("SessionUser", JsonConvert.SerializeObject(user));
                return RedirectToAction("Index", "Customer", user);
            }
            return RedirectToAction("Index", "Home");
        }

        [HttpPost]
        public IActionResult SignUp(User user)
        {
            if(user == null)
            {
                return RedirectToAction("Index", "Home");
            }
            return RedirectToAction("CustomerLogin", "Home"); 
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
