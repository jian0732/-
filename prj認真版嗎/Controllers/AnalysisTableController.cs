using Microsoft.AspNetCore.Mvc;
using prj認真版嗎.Models;
using prj認真版嗎.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace prj認真版嗎.Controllers
{
    public class AnalysisTableController : Controller
    {
        public AnalysisTableController(PlanetTravelContext db)
        {
            _db = db;
            
        }
        private PlanetTravelContext _db;
        public IActionResult Index()
        {
            _db.OrderStatuses.ToList();
            _db.OrderDetails.ToList();
            var Od = _db.Orders.ToList();

            C統計表 j統計 = new C統計表();
<<<<<<<< HEAD:prj認真版嗎/Controllers/AnalysisTableController.cs
            var j當年當月表訂單表 = Od.Where(p => Convert.ToDateTime(p.OrderDate).Year == DateTime.Now.Year && Convert.ToDateTime(p.OrderDate).Month == DateTime.Now.Month && p.OrderStatusId == 3).ToList();
========
            var j當年當月表訂單表 = Od.Select(p => Convert.ToDateTime(p.OrderDate).Year == DateTime.Now.Year && Convert.ToDateTime(p.OrderDate).Month == DateTime.Now.Month).ToList();
>>>>>>>> 1107 1019:prj認真版嗎/Controllers/AnalysisTable.cs

            j統計.待處理 = Od.Where(p => p.OrderStatusId == 1).ToList().Count();

            j統計.當月訂單量 = j當年當月表訂單表.Count();

            j統計.當月目前營業額 = Od.Where(p => Convert.ToDateTime(p.OrderDate).Year == DateTime.Now.Year && Convert.ToDateTime(p.OrderDate).Month == DateTime.Now.Month && p.OrderStatusId == 3)
                .Select(p => p.OrderDetails.Select(p => p.UnitPrice * p.Quantity).Sum()).Sum();


            return View(j統計);
        }

        public IActionResult AA()
        {
            var Od = _db.Orders.ToList();
            _db.OrderDetails.ToList();
            _db.Members.ToList();
            var Od = _db.Orders.ToList();
            var Odd = _db.OrderDetails.ToList();
            var Tp = _db.TravelProducts.ToList();
            _db.Countries.ToList();

            string 國家 = "";
            string 營業額 = "";
            decimal 營業總額 = 0;
            foreach (var i in j年份)
            {
                營業總額 += i.營業額;
                國家 += i.國家 + ",";
                營業額 += i.營業額.ToString("0") + ",";
            }
            ViewBag.今年營業總額 = 營業總額.ToString("C0");
            ViewBag.國家 = 國家;
            ViewBag.營業額 = 營業額;
            var 正常筆數 = Od.Where(p => p.OrderStatusId == 3).Count();


            j年份 = _db.Orders.Where(p => p.OrderStatusId == 3).GroupBy(s => s.Members.Gender).Select(p => new C年份營業額統計
            {
                性別 = p.Key + ((Convert.ToDouble(p.Count()) / Convert.ToDouble(正常筆數)) * 100).ToString("#.#0") + "%",
                比例 = (Convert.ToDouble(p.Count()) / Convert.ToDouble(正常筆數)) * 100,
                消費比數 = p.Count(),
            }).ToList();

            string 性別 = "";
            string 性別比例 = "";
            string 消費比數 = "";
            foreach (var i in j年份)
            {
                性別 += i.性別 + ",";
                性別比例 += i.比例 + ",";
                消費比數 += i.消費比數 + ",";
            }
            if (性別.Substring(性別.Length - 1, 1) == ",")
            {
                性別 = 性別.Substring(0, 性別.Length - 1);
            }
            if (性別比例.Substring(性別比例.Length - 1, 1) == ",")
            {
                性別比例 = 性別比例.Substring(0, 性別比例.Length - 1);
            }
            if (消費比數.Substring(消費比數.Length - 1, 1) == ",")
            {
                消費比數 = 消費比數.Substring(0, 消費比數.Length - 1);
            }
            ViewBag.性別 = 性別;
            ViewBag.性別比例 = 性別比例;
            ViewBag.消費比數 = 消費比數;
========
            C年份營業額統計 j年份 = new C年份營業額統計();

        }
        public IActionResult BB()
        {
<<<<<<<< HEAD:prj認真版嗎/Controllers/AnalysisTableController.cs
            _db.Members.ToList();
            var Od = _db.Orders.ToList();
            var Odd = _db.OrderDetails.ToList();
            var Tp = _db.TravelProducts.ToList();
            _db.Countries.ToList();
            List<C年份營業額統計> j年份 = new List<C年份營業額統計>();

            j年份 = Od.Where(p => Convert.ToDateTime(p.OrderDate).Year == DateTime.Now.Year && Convert.ToDateTime(p.OrderDate).Month == DateTime.Now.Month && p.OrderStatusId == 3)
     .Join(
         Odd,
         comp => comp.OrderId,
         sect => sect.OrderId,
         (comp, sect) => new { order = comp, orderdetail = sect })
     .Join(
         Tp,
         cs => cs.orderdetail.TravelProductId,
         dsi => dsi.TravelProductId,
         (cs, dsi) => new { cs.order, cs.orderdetail, Products = dsi })
     .GroupBy(c => c.Products.Country.CountryName).Select(s => new C年份營業額統計
     {
         國家 = s.Key,
         營業額 = s.Sum(p => p.orderdetail.Quantity * p.orderdetail.UnitPrice)
     }).ToList();

            string 國家 = "";
            string 營業額 = "";
            foreach (var i in j年份)
            {
                國家 += i.國家 + ",";
                營業額 += i.營業額.ToString("0") + ",";
            }
            if (國家.Substring(國家.Length - 1, 1) == ",")
            {
                國家 = 國家.Substring(0, 國家.Length - 1);
            }
            if (營業額.Substring(營業額.Length - 1, 1) == ",")
            {
                營業額 = 營業額.Substring(0, 營業額.Length - 1);
            }
            ViewBag.M國家 = 國家;
            ViewBag.M營業額 = 營業額;

            var C當月訂單 = Od.Where(p => Convert.ToDateTime(p.OrderDate).Year == DateTime.Now.Year && Convert.ToDateTime(p.OrderDate).Month == DateTime.Now.Month && p.OrderStatusId == 3).OrderBy(p => p.OrderDate)
                .Select(p => new C當月訂單統計
                {
                    訂單日期 = Convert.ToDateTime(p.OrderDate).ToString("yyyy-MM-dd"),
                    產品編號 = p.OrderId,
                    旅遊地區 = p.OrderDetails.Where(q => q.OrderId == p.OrderId).Select(p => p.TravelProduct.Country.CountryName).FirstOrDefault(),
                    金額 = p.OrderDetails.Where(q => q.OrderId == p.OrderId).Sum(s => s.Quantity * s.UnitPrice),
                }).ToList();


            var 訂單量 = Od.Where(p => Convert.ToDateTime(p.OrderDate).Year == DateTime.Now.Year && Convert.ToDateTime(p.OrderDate).Month == DateTime.Now.Month && p.OrderStatusId == 3)
         .Join(
         Odd,
         comp => comp.OrderId,
         sect => sect.OrderId,
         (comp, sect) => new { order = comp, orderdetail = sect })
         .GroupBy(p => p.orderdetail.TravelProductId).Select(s => new C當月訂單統計
         {
             //國家=s.First(s=>s.orderdetail.TravelProduct.Country.CountryName),
             產品編號最多=s.Key,
             產品編號最多訂單量=s.Count(),
         }).OrderByDescending(p=>p.產品編號最多訂單量).Take(3).ToList();






            var 訂單國 = Od.Where(p => Convert.ToDateTime(p.OrderDate).Year == DateTime.Now.Year && Convert.ToDateTime(p.OrderDate).Month == DateTime.Now.Month && p.OrderStatusId == 3)
        .Join(
        Odd,
        comp => comp.OrderId,
        sect => sect.OrderId,
        (comp, sect) => new { order = comp, orderdetail = sect })
        .GroupBy(p => p.orderdetail.TravelProduct.Country.CountryName).Select(s => new C當月訂單統計
        {
            國家 = s.Key,
            訂單量 = s.Count(),








            return ViewComponent("AnalysisTable2", C當月訂單);
        }
        public IActionResult Mm()
        {
            return ViewComponent("AnalysisTable3");
        }

========
            return ViewComponent("AnalysisTable2");
        }
>>>>>>>> 1107 1019:prj認真版嗎/Controllers/AnalysisTable.cs
    }
}
