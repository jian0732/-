using Microsoft.AspNetCore.Hosting;
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
        //public ActionResult testList()
        //{
        //    CTravelProduct_Picture_List abc = new CTravelProduct_Picture_List();
        //    abc.pro = _db.TravelProducts.Select(p=>p).ToList();
        //    return View(abc);
        //}
        public IActionResult List()
        {

               CTravelProduct_Picture_List result = new CTravelProduct_Picture_List();
            result.產品列表 = (from c in _db.TravelProducts
                           select new 產品格式
                           {
                               TravelProductName = c.TravelProductName,
                               TravelProductId = c.TravelProductId,
                               Price = c.Price,
                               TravelProductTypeId = c.TravelProductId,
                               Stocks = c.Stocks,
                               Description = c.Description,
                               CountryId = c.CountryId,
                               Cost = c.Cost,
                               EventIntroduction = c.EventIntroduction,
                               PreparationDescription = c.PreparationDescription,
                               TravelPicture1 = c.TravelPictures.Where(pic => pic.TravelProductId == c.TravelProductId).FirstOrDefault().TravelPicture1,
                               
                           }).ToList();

            return View(result);
        }
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(CCreateTravelProductViewModel newProduct)
        {
            if (newProduct != null)
            {
                TravelProduct tp = new TravelProduct
                {
                    TravelProductName = newProduct.TravelProductName,
                    Price = newProduct.Price,
                    TravelProductTypeId = newProduct.TravelProductTypeId,
                    Stocks = newProduct.Stocks,
                    Description = newProduct.Description,
                    CountryId = newProduct.CountryId,
                    Cost = newProduct.Cost,
                    EventIntroduction = newProduct.EventIntroduction,
                    PreparationDescription = newProduct.PreparationDescription,
                };

                _db.TravelProducts.Add(tp);
                _db.SaveChanges();


                if (newProduct.photo != null)
                {
                    foreach (IFormFile travel_pictures in newProduct.photo)
                    {
                        TravelPicture pic = new TravelPicture();
                        pic.TravelPictureText = newProduct.TravelPictureText;
                        pic.TravelProductId = _db.TravelProducts.OrderBy(e => e.TravelProductId).LastOrDefault().TravelProductId;

                        string pname = Guid.NewGuid().ToString() + ".jpg";
                        pic.TravelPicture1 = pname;
                        string path = _enviro.WebRootPath + "/images/TravelProductPictures/" + pname;

                        travel_pictures.CopyTo(new FileStream(path, FileMode.Create));
                        _db.TravelPictures.Add(pic);
                        _db.SaveChanges();
                    }

                }


            }

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
                                               Description = s.Description,
                                               CountryId = s.CountryId,
                                               Cost = s.Cost,
                                               EventIntroduction = s.EventIntroduction,
                                               PreparationDescription = s.PreparationDescription,
                                               TravelPictureId = s.TravelPictures.Select(p=>p.TravelPictureId).ToList(),
                                               TravelPicturePath= s.TravelPictures.Select(p => p.TravelPicture1).ToList(),
                                               TravelPictureText= s.TravelPictures.Select(p => p.TravelPictureText).ToList(),                                       
                                           }).FirstOrDefault();
                if (prod != null)
                {                   
                    return View(prod);
                }
            }
            return RedirectToAction("List");
        }
        [HttpPost]
        public ActionResult Edit(CProductViewModel inProd)
        {
            TravelProduct c = _db.TravelProducts.FirstOrDefault(p => p.TravelProductId == inProd.TravelProductId);
            if (c != null)
            {
                c.TravelProductName = inProd.TravelProductName;
                c.Price = inProd.Price;
                c.TravelProductTypeId = inProd.TravelProductTypeId;
                c.Stocks = inProd.Stocks;
                c.Description = inProd.Description;
                c.CountryId = inProd.CountryId;
                c.Cost = inProd.Cost;
                c.EventIntroduction = inProd.EventIntroduction;
                c.PreparationDescription = inProd.PreparationDescription;
                _db.SaveChanges();
                if (inProd.photo != null)
                {
                    int tempCount = 0;
                    for (int i = 0; i < inProd.PictureCount.Count; i++)
                    {
                        if (inProd.PictureCount[i] != 0) //點下選取圖片就會變1
                        {
                            var TraPicture = _db.TravelPictures.Where(pic => pic.TravelPictureId == inProd.TravelPictureId[i]).FirstOrDefault();
                            string pname = Guid.NewGuid().ToString() + ".jpg";
                            TraPicture.TravelPicture1 = pname;
                            string path = _enviro.WebRootPath + "/images/TravelProductPictures/" + pname;
                            if (inProd.photo[tempCount] != null)
                            {
                                inProd.photo[tempCount].CopyTo(new FileStream(path, FileMode.Create));
                                _db.SaveChanges();
                                tempCount++;
                            }                          
                        }
                    }
                }
                if (inProd.TravelPictureText != null)
                {
                    for (int i = 0; i < inProd.TravelPictureText.Count; i++)
                    {
                        var TraPicture = _db.TravelPictures.Where(pic => pic.TravelPictureId == inProd.TravelPictureId[i]).FirstOrDefault();
                        TraPicture.TravelPictureText = inProd.TravelPictureText[i];
                        _db.SaveChanges();
                    }
                }
                if(inProd.CreateNewPhoto != null)
                {
                    for (int i = 0; i < inProd.CreateNewPhoto.Count; i++)
                    {
                        TravelPicture pic = new TravelPicture();
                        pic.TravelPictureText = inProd.CreateNewTravelPictureText[i];
                        pic.TravelProductId = inProd.TravelProductId;

                        string pname = Guid.NewGuid().ToString() + ".jpg";
                        pic.TravelPicture1 = pname;
                        string path = _enviro.WebRootPath + "/images/TravelProductPictures/" + pname;

                        inProd.CreateNewPhoto[i].CopyTo(new FileStream(path, FileMode.Create));
                        _db.TravelPictures.Add(pic);
                        _db.SaveChanges();
                    }
                }
            }

            return RedirectToAction("List");
        }
        //[HttpPost] 失敗
        //public ActionResult Edit(FormCollection inPord)
        //{
        //    TravelProduct c = _db.TravelProducts.FirstOrDefault(p => p.TravelProductId == inPord["TravelProductId"]);
        //    if (c != null)
        //    {
        //        c.TravelProductName = inPord["TravelProductName"];
        //        c.Price = Convert.ToDecimal(inPord["Price"]);
        //        c.TravelProductTypeId = Convert.ToInt32(inPord["TravelProductTypeId"]);
        //        c.Stocks = Convert.ToInt32(inPord["Stocks"]);
        //        c.Description = inPord["Description"];
        //        c.CountryId = Convert.ToInt32(inPord["CountryId"]);
        //        c.Cost = Convert.ToInt32(inPord["Cost"]);
        //        c.EventIntroduction = inPord["EventIntroduction"];
        //        c.PreparationDescription = inPord["PreparationDescription"];
        //        //_db.SaveChanges();
        //        if (inPord["photo"].Count > 0)
        //        {
        //            var TraPicture = _db.TravelPictures.Where(pic => pic.TravelProductId == c.TravelProductId).FirstOrDefault();
        //            TraPicture.TravelPictureText = inPord["TravelPictureText"];

        //            string pname = Guid.NewGuid().ToString() + ".jpg";
        //            TraPicture.TravelPicture1 = pname;
        //            string path = _enviro.WebRootPath + "/images/TravelProductPictures/" + pname;
        //            var temp = inPord["photo"] as IFormFile;
        //            //temp.CopyTo(new FileStream(path, FileMode.Create));
        //            //_db.SaveChanges();
        //        }
        //    }

        //    return RedirectToAction("List");
        //}
        public IActionResult IndexHome()
        {
         
            return View();
        }
    }
}
