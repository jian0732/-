using Microsoft.AspNetCore.Mvc;
using prj認真版嗎.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace prj認真版嗎.Controllers
{
    public class CommentController : Controller
    {
        public CommentController(PlanetTravelContext _PTdb)
        {
            _db = _PTdb;
        }
        private PlanetTravelContext _db;
        public IActionResult List()
        {
            var q = _db.Comments.Select(p=>p.TravelProduct.TravelProductName).ToList();

            return View(q);
        }
        [HttpPost]
        public IActionResult Delete()
        {

            return View();
        }
    }
}
