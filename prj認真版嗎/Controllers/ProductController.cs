using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MimeKit;
using MimeKit.Utils;
using prjMvcCoreModel.ViewModel;
using prj認真版嗎.Authorization;
using prj認真版嗎.Models;
using prj認真版嗎.ViewModel;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using MailKit.Net.Smtp;

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
            
            CTravelProduct_Picture_List result = new CTravelProduct_Picture_List();
            result.產品列表 = (from c in _db.TravelProducts
                           orderby c.TravelProductId descending
                           select new 產品格式
                           {
                               TravelProductName = c.TravelProductName,
                               TravelProductId = c.TravelProductId,
                               Price = c.Price,
                               TravelProductTypeId = c.TravelProductTypeId,
                               TravelProductTypeDisplayName = c.TravelProductType.TravelProductTypeName,
                               Stocks = c.Stocks,
                               Description = StripHTML(c.Description),
                               CountryId = c.CountryId,
                               CountryDisplayName = c.Country.CountryName,
                               Cost = c.Cost,
                               EventIntroduction = c.EventIntroduction,
                               PreparationDescription = c.PreparationDescription,
                               TravelPicture1 = c.TravelPictures.Where(pic => pic.TravelProductId == c.TravelProductId).FirstOrDefault().TravelPicture1,
                               ProductStatus = c.ProductStatus,                               
                           }).ToList();

            return View(result);
        }
        // 把描述中的html標籤去除
        public static string StripHTML(string input) 
        { if (input == null) return ""; 
            return Regex.Replace(input, "<[a-zA-Z/].*?>", String.Empty); }
        [HttpPost]
        public IActionResult List(List<int> TravelProductID_Status)
        {
            foreach (int itemID in TravelProductID_Status)
            {
                var q  = _db.TravelProducts.Where(p => p.TravelProductId == itemID).FirstOrDefault();
                if (q.ProductStatus == "未上架")
                    q.ProductStatus = "已上架";
                else
                    q.ProductStatus = "未上架";
            }
            _db.SaveChanges();
            return RedirectToAction("List");
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
                    Quantity= newProduct.Stocks,
                    Description = newProduct.Description,                    
                    CountryId = newProduct.CountryId,
                    Cost = newProduct.Cost,
                    EventIntroduction = newProduct.EventIntroduction,
                    PreparationDescription = newProduct.PreparationDescription,
                    MapUrl = newProduct.MapUrl,
                    AnotherDepartureDate = newProduct.AnotherDepartureDate,
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
                if(newProduct._TravelProductDetail != null) 
                {
                    foreach (var list in newProduct._TravelProductDetail)
                    {
                        TravelProductDetail tpd = new TravelProductDetail();
                        tpd.TravelProductId = _db.TravelProducts.OrderBy(e => e.TravelProductId).LastOrDefault().TravelProductId;
                        tpd.Day = list.Day;
                        tpd.Date = list.Date;
                        tpd.DailyDetailText = list.DailyDetailText;
                        if (list.HotelId != -1)
                            tpd.HotelId = list.HotelId;
                        _db.TravelProductDetails.Add(tpd);
                        _db.SaveChanges();
                        int latest_DetailID = _db.TravelProductDetails.OrderBy(e => e.TravelProductDetailId).LastOrDefault().TravelProductDetailId;
                        foreach (int TrasportationID in list.TrasportationID)
                        {
                            ProductToTransportation ptt = new ProductToTransportation
                            {
                                TravelProductDetailId = latest_DetailID,
                                TrasportationId = TrasportationID,
                            };
                            _db.ProductToTransportations.Add(ptt);
                        }
                        foreach (int ViewID in list.ViewID)
                        {
                            if (ViewID != -1) 
                            {
                                ProductToView ptv = new ProductToView
                                {
                                    TravelProductDetailId = latest_DetailID,
                                    ViewId = ViewID,
                                };
                                _db.ProductToViews.Add(ptv);
                            }
                        }
                        if (list._CreateView != null)
                        {                            
                            foreach (CreateView cv in list._CreateView)
                            {
                                View v = new View
                                {
                                    CityId = cv.CreateViewCityID,
                                    ViewName = cv.CreateViewName,
                                };
                                _db.Views.Add(v);
                                _db.SaveChanges();
                                ProductToView ptv = new ProductToView
                                {
                                    TravelProductDetailId = latest_DetailID,
                                    ViewId = _db.Views.OrderBy(e => e.ViewId).LastOrDefault().ViewId,
                                };
                                _db.ProductToViews.Add(ptv);
                            }
                            _db.SaveChanges();
                        }

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

                CProductViewModel prod = _db.TravelProducts.Where(p => p.TravelProductId == id)
                                           .Select(s => new CProductViewModel
                                           {
                                               TravelProductId = s.TravelProductId,
                                               TravelProductName = s.TravelProductName,
                                               Price = s.Price,
                                               TravelProductTypeId = s.TravelProductTypeId,
                                               TravelProductTypeName = s.TravelProductType.TravelProductTypeName,
                                               Stocks = s.Stocks,
                                               Description = s.Description,
                                               CountryId = s.CountryId,
                                               CountryName=s.Country.CountryName,
                                               Cost = s.Cost,
                                               EventIntroduction = s.EventIntroduction,
                                               PreparationDescription = s.PreparationDescription,
                                               TravelPictureId = s.TravelPictures.Select(p => p.TravelPictureId).ToList(),
                                               TravelPicturePath = s.TravelPictures.Select(p => p.TravelPicture1).ToList(),
                                               TravelPictureText = s.TravelPictures.Select(p => p.TravelPictureText).ToList(),
                                               MapUrl = s.MapUrl,
                                               Quantity = s.Quantity,
                                               AnotherDepartureDate = s.AnotherDepartureDate,
                                               _CTravelDetailForEditViewModel = s.TravelProductDetails.Select(p => new CTravelDetailForEditViewModel
                                               {
                                                   _TravelProductDetail = p,
                                                   TrasportationName = p.ProductToTransportations.Select(t => t.Trasportation.TrasportationName).ToList(),
                                                   ViewName = p.ProductToViews.Select(v => v.View.ViewName).ToList(),
                                                   HotelName = p.Hotel.HotelName,
                                               }).ToList(),

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
            int tempStocks = 0;
            //部分功能未完善，待補
            TravelProduct c = _db.TravelProducts.FirstOrDefault(p => p.TravelProductId == inProd.TravelProductId);
            if (c != null)
            {
                //紀錄當下產品庫存
                tempStocks = c.Stocks;

                //修改相關資訊
                c.TravelProductName = inProd.TravelProductName;
                c.Price = inProd.Price;
                //c.TravelProductTypeId = inProd.TravelProductTypeId;
                c.Stocks = inProd.Stocks;
                c.Description = inProd.Description;
                //c.CountryId = inProd.CountryId;
                c.Cost = inProd.Cost;
                c.EventIntroduction = inProd.EventIntroduction;
                c.PreparationDescription = inProd.PreparationDescription;
                _db.SaveChanges();

                //如果庫存增加則寄送Email給關注該產品的客戶
                if (tempStocks ==0 && inProd.Stocks > tempStocks)
                {
                    CCsendmailcs 商品描述 = new CCsendmailcs();
                    var em = _db.Members.ToList();
                    var myf = _db.Myfavorites.Where(a => a.TravelProductId == inProd.TravelProductId).Select(a => a.Members.Email).ToList();
                    if (myf.Count != 0)
                    {
                        商品描述 = (from a in _db.TravelProducts.Where(a => a.TravelProductId == inProd.TravelProductId)
                                select new CCsendmailcs
                                {
                                    商品名稱 = a.TravelProductName,
                                    商品照片 = a.TravelPictures.Where(a => a.TravelProductId == inProd.TravelProductId).Select(a => a.TravelPicture1).FirstOrDefault(),
                                    商品價格 = a.Price,
                                    商品描述 = a.EventIntroduction,
                                    商品詳情 = a.Description,
                                }).FirstOrDefault();

                        MimeMessage message = new MimeMessage();
                        BodyBuilder builder = new BodyBuilder();
                        var mu = new Multipart();
                        string imgPath = _enviro.WebRootPath + "/Images/logoRefer.png";

                        var image = builder.LinkedResources.Add(imgPath);

                        image.ContentId = MimeUtils.GenerateMessageId();

                        var attach = new MimePart("image", "PNG")
                        {
                            FileName = Path.GetFullPath(imgPath)
                        };

                        builder.HtmlBody =
                                            $"<img width:80px src='cid:{image.ContentId}'/>" +
                                           $"<p>您好，您關注的商品更新了!</p>" +
                                            $"<div class='container col-md-12'>" +
                                            $"<a href='https://localhost:44302/shopping/List?TravelProductId={inProd.TravelProductId}'>" +
                                             $"<h3>{商品描述.商品名稱}</h3>" + $"</a>" +
                                              $"<img src='https://localhost:44338/images/TravelProductPictures/{商品描述.商品照片}'width='600px''>" +
                                              $"<p>{商品描述.商品描述}</p>" +
                                              $"<p>{商品描述.商品詳情}</p>" +
                                              $"<p style='red'> 驚喜價格:{商品描述.商品價格.ToString("###,0")}元!</p>" +
                                            $"</div>" +
                                          $"<div style='border: 2px solid black;text-align: center;'>      </div>" +
                                          $"<p>傳送時間:{DateTime.Now:yyyy-MM-dd HH:mm:ss}</p>";

                        message.From.Add(new MailboxAddress("PlanetTraveler星球旅遊", "planetmait143-1@outlook.com"));
                        foreach (var item in myf)
                        {
                            message.To.Add(new MailboxAddress("", item));
                        }

                        message.Subject = "PlanetTraveler星球旅遊";
                        message.Body = builder.ToMessageBody();

                        using (SmtpClient client = new SmtpClient())
                        {
                            client.Connect("smtp.outlook.com", 25, MailKit.Security.SecureSocketOptions.StartTls);
                            client.Authenticate("planetmait143-1@outlook.com", "gogo1116");
                            client.Send(message);
                            client.Disconnect(true);
                        }
                        //return Json(new { Res = true });
                    }
                }

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
                        TraPicture.PicturePurpose = 2;
                        _db.SaveChanges();
                    }
                }
                if (inProd.CreateNewPhoto != null)
                {
                    for (int i = 0; i < inProd.CreateNewPhoto.Count; i++)
                    {
                        TravelPicture pic = new TravelPicture();
                        pic.TravelPictureText = inProd.CreateNewTravelPictureText[i];
                        pic.TravelProductId = inProd.TravelProductId;
                        pic.PicturePurpose = 2;
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
        //測試用的頁面 可以隨時刪除
        public IActionResult testaaaa()
        {
            return View();
        }
        
        public IActionResult IndexHome()
        {

            return View();
        }

        
        public IActionResult LoadTravelProductType_ReturnJson()
        {
            var TravelProductType_JsonData = _db.TravelProductTypes.ToList();
            //_PlanetTravelContext.Cities.Where(a => a.CityId != id && a.CountryId == 1).Select(a => a.CityName);
            return Json(TravelProductType_JsonData);
        }
        public IActionResult LoadCountryName_ReturnJson()
        {
            var CountryName_JsonData = _db.Countries.ToList();
            return Json(CountryName_JsonData);
        }
        public IActionResult LoadCityName_ReturnJson(string Country)
        {
            var CityName_JsonData = _db.Cities.Where(c=>c.Country.CountryName==Country).ToList();
            return Json(CityName_JsonData);
        }
        public IActionResult LoadHotelName_ReturnJson(string Country)
        {
            var HotelName_JsonData = _db.Hotels.Where(h=>h.City.Country.CountryName==Country).ToList();
            return Json(HotelName_JsonData);
        }
        public IActionResult LoadViewName_ReturnJson(string Country)
        {
            var ViewName_JsonData = _db.Views.Where(v=>v.City.Country.CountryName== Country).ToList();
            return Json(ViewName_JsonData);
        }
        public IActionResult LoadTrasportationName_ReturnJson()
        {
            var TrasportationName_JsonData = _db.Trasportations.ToList();
            return Json(TrasportationName_JsonData);
        }

    }
}
