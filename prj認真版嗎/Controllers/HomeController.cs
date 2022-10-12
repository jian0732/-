using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using prj認真版嗎.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
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
        public IActionResult Index()
        {
            return View();
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
        public IActionResult Login(string password)
        {
            if (password != "")
            {
                var q = _Travel.Admins.FirstOrDefault(p => p.Password == password);
                if(q != null)
                {
                 
                }
                else
                {

                }
                
            }

            return RedirectToAction("Index");
        }
    }
}
