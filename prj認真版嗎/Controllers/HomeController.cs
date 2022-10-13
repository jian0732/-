using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using prj認真版嗎.Models;
using prj認真版嗎.ViewModel;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace prj認真版嗎.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly PlanetTravelContext _Travel;
        public HomeController(ILogger<HomeController> logger, PlanetTravelContext Travel)
        {
            _Travel = Travel;
            _logger = logger;
        }
        public IActionResult page()
        {
            return View();
        }
        public IActionResult Index()
        {
            if (!HttpContext.Session.Keys.Equals(CDictionary.SK_Admin_Login))
                return View();
            return RedirectToAction("page");
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Login(CLogin ps)
        {
            if (!string.IsNullOrEmpty(ps.password))
            {
                var q = _Travel.Admins.FirstOrDefault(p => p.Password == ps.password);
                if(q != null)
                {                   
                    string jsonUser = JsonSerializer.Serialize(q);
                    HttpContext.Session.SetString(CDictionary.SK_Admin_Login, jsonUser);
                    return Content("0", "text / plain", System.Text.Encoding.UTF8);
                }
                else
                {
                    return Content("1", "text / plain", System.Text.Encoding.UTF8);
                }
            }

            return RedirectToAction("page");
        }
    }
}
