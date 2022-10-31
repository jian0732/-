using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using prjMvcCoreModel.ViewModel;
using prj認真版嗎.Authorization;
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
        private readonly PlanetTravelContext _db;

        public HomeController(ILogger<HomeController> logger, PlanetTravelContext Travel)
        {
            _db = Travel;
            _logger = logger;
        }
        [AuthorizationManeger]
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
        public IActionResult Logout()
        {
            HttpContext.Session.Remove(CDictionary.SK_Admin_Login);
            return RedirectToAction("Login");
        }
        [AllowAnonymous]
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Login(CLoginViewModel ps)
        {
            Admin x = _db.Admins.FirstOrDefault(p => p.Account.Equals(ps.txt帳號));
             
            if (x!=null)
            {
                if(x.Password.Equals(ps.txt密碼))
                {
                    CAdminViewModel qq = _db.Admins.Where(p => p.AdminId == x.AdminId).Select(s => new CAdminViewModel
                    { 
                        admin = x,
                        CommentStatus = s.AdminStatuses.Select(s => s.CommentStatus).FirstOrDefault(),
                        MemberStatus = s.AdminStatuses.Select(s => s.MemberStatus).FirstOrDefault(),
                        AdminStatus1 = s.AdminStatuses.Select(s => s.AdminStatus1).FirstOrDefault(),
                        ProductStatus = s.AdminStatuses.Select(s => s.ProductStatus).FirstOrDefault(),
                    }).FirstOrDefault();

                    if (qq != null) 
                    {
                    string jsonUser = JsonSerializer.Serialize(qq);
                    HttpContext.Session.SetString(CDictionary.SK_Admin_Login, jsonUser);
                        return RedirectToAction("page");
                    }
                    else
                    return RedirectToAction("Login");                   
                }
            }
            return View("Login");
        }
    }
}
