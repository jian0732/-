﻿using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using prjMvcCoreModel.ViewModel;
using prj認真版嗎.Models;
using prj認真版嗎.ViewModel;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace prj認真版嗎.Controllers
{
    public class ProductController : Controller
    {
        //1014-product edit
        private IWebHostEnvironment _enviro;
        private PlanetTravelContext _db;
        public ProductController(IWebHostEnvironment p, PlanetTravelContext q)
        {
            _db = q;
            _enviro = p;
        }
        public IActionResult List()
        {
            //var qq = from p in _db.TravelProducts
            //         select p;
            var products_list = _db.TravelProducts.Select(p => p);
            return View(products_list);
        }
        [HttpGet]
        public ActionResult Create()
        {
            return View();
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
                //TravelProduct prod = _db.TravelProducts.FirstOrDefault(p => p.TravelProductId == id);
                CProductViewModel prod = _db.TravelProducts.Where(p => p.TravelProductId == id)
                                           .Select(s => new CProductViewModel
                                           {
                                               product = s,
                                               TravelProductId = s.TravelProductId,
                                               TravelProductName = s.TravelProductName,
                                               Price = s.Price,
                                               TravelProductTypeId = s.TravelProductTypeId,
                                               Stocks = s.Stocks,
                                               Description =s.Description,
                                               CountryId = s.CountryId,
                                               Cost = s.Cost,
                                               EventIntroduction = s.EventIntroduction,
                                               PreparationDescription =s.PreparationDescription,
                                               TravelPictureText = s.TravelPictures.Where(pic=>pic.TravelProductId==id).FirstOrDefault().TravelPictureText,
                                           }).FirstOrDefault();
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
                c.TravelProductName = inPord.TravelProductName;
                c.Price = inPord.Price;
                c.TravelProductTypeId = inPord.TravelProductTypeId;
                c.Stocks = inPord.Stocks;
                c.Description = inPord.Description;
                c.CountryId = inPord.CountryId;
                c.Cost = inPord.Cost;
                c.EventIntroduction = inPord.EventIntroduction;
                c.PreparationDescription = inPord.PreparationDescription;
                _db.SaveChanges();
                if (inPord.photo != null)
                {
                    var TraPicture = _db.TravelPictures.Where(pic => pic.TravelProductId == c.TravelProductId).FirstOrDefault();                    
                    TraPicture.TravelPictureText = inPord.TravelPictureText;

                    string pname = Guid.NewGuid().ToString() + ".jpg";
                    TraPicture.TravelPicture1 = pname;
                    string path = _enviro.WebRootPath + "/images/TravelProductPictures/" + pname;
                    inPord.photo.CopyTo(new FileStream(path, FileMode.Create));
                    _db.SaveChanges();
                }
            }

            return RedirectToAction("List");
        }
        public IActionResult IndexHome()
        {
          
            return View();
        }
    }
}
