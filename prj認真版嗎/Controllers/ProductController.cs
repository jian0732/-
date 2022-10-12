using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using prjMvcCoreModel.ViewModel;
using prj認真版嗎.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace prj認真版嗎.Controllers
{
    public class ProductController : Controller
    {
        private IWebHostEnvironment _enviro;
        private PlanetTravelContext _db;
        public ProductController(IWebHostEnvironment p, PlanetTravelContext q)
        {
            _db = q;
            _enviro = p;
        }
        public IActionResult List()
        {
            var qq = from p in _db.TravelProducts
                     select p;
            return View(qq);
        }
        [HttpGet]
        public ActionResult Create()
        {
            return PartialView();
        }

        [HttpPost]
        public ActionResult Create(TravelProduct p)
        {
            _db.TravelProducts.Add(p);
            _db.SaveChanges();
            return RedirectToAction("List");
        }
        public ActionResult Edit(int? id)
        {
            if (id != null)
            {
                TravelProduct prod = _db.TravelProducts.FirstOrDefault(p => p.TravelProductId == id);
                if (prod != null)
                {
                    return View(prod);
                }
            }
            return RedirectToAction("List");
        }
        [HttpPost]
        public ActionResult Edit(CProductViewModel inPord)
        {
            TravelProduct c = _db.TravelProducts.FirstOrDefault(p => p.TravelProductId == inPord.TravelProductId);
            if (c != null)
            {
                if (inPord.photo != null)
                {
                    string pname = Guid.NewGuid().ToString() + ".jpg";
                    //c.FimagePath = pname;
                    string path = _enviro.WebRootPath + "/images/" + pname;
                    inPord.photo.CopyTo(new FileStream(path, FileMode.Create));
                }
                c.Cost = inPord.Cost;
                c.TravelProductName = inPord.TravelProductName;
                c.Price = inPord.Price;
                //c.FQty = inPord.FQty;
                _db.SaveChanges();
            }
            return RedirectToAction("List");
        }
        public IActionResult IndexHome()
        {
          
            return View();
        }
    }
}
