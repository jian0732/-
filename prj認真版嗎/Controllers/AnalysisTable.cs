using Microsoft.AspNetCore.Mvc;
using prj認真版嗎.Models;
using prj認真版嗎.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace prj認真版嗎.Controllers
{
    public class AnalysisTable : Controller
    {
        public AnalysisTable(PlanetTravelContext db)
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
            var j當年當月表訂單表 = Od.Select(p => Convert.ToDateTime(p.OrderDate).Year == DateTime.Now.Year && Convert.ToDateTime(p.OrderDate).Month == DateTime.Now.Month).ToList();

            j統計.待處理 = Od.Where(p => p.OrderStatusId == 1).ToList().Count();

            j統計.當月訂單量 = j當年當月表訂單表.Count();

            j統計.當月目前營業額 = Od.Where(p => Convert.ToDateTime(p.OrderDate).Year == DateTime.Now.Year && Convert.ToDateTime(p.OrderDate).Month == DateTime.Now.Month)
                .Select(p => p.OrderDetails.Select(p => p.UnitPrice * p.Quantity).Sum()).Sum();

            j統計.當月取消筆數 = Od.Where(p => p.OrderStatusId == 4).ToList().Count();

            return View(j統計);
        }

        public IActionResult AA()
        {
            _db.Members.ToList();
            var Od = _db.Orders.ToList();
            var Odd = _db.OrderDetails.ToList();
            var Tp = _db.TravelProducts.ToList();
            _db.Countries.ToList();

            List<C年份營業額統計> j年份 = new List<C年份營業額統計>();

            j年份 = Od.Where(p => Convert.ToDateTime(p.OrderDate).Year == DateTime.Now.Year)
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
            ViewBag.國家 = 國家;
            ViewBag.營業額 = 營業額;
            j年份 = _db.Orders.GroupBy(s => s.Members.Gender).Select(p => new C年份營業額統計
            {
                性別 = p.Key+ (Convert.ToDouble(p.Count()) / Convert.ToDouble(Od.Count())) * 100+"%",
                比例 = (Convert.ToDouble(p.Count()) / Convert.ToDouble(Od.Count()))*100,
                消費比數= p.Count(),
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
            if(性別.Substring(性別.Length - 1, 1) == ",") {
                性別 = 性別.Substring(0, 性別.Length-1);
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

            return ViewComponent("AnalysisTable");
        }
        public IActionResult BB()
        {
            return ViewComponent("AnalysisTable2");
        }
    }
}
