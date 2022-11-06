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

            j統計.當月取消筆數 = Od.Where(p => p.OrderStatus.OrderStatusName == "取消訂單").ToList().Count();

            return View(j統計);
        }

        public IActionResult AA()
        {
            var Od = _db.Orders.ToList();
            _db.OrderDetails.ToList();
            _db.Members.ToList();

            C年份營業額統計 j年份 = new C年份營業額統計();

            //j年份.月份10 = Od.Where(p => Convert.ToDateTime(p.OrderDate).Year == DateTime.Now.Year && Convert.ToDateTime(p.OrderDate).Month == 10)
            //                    .Select(p => p.OrderDetails.Select(p => p.UnitPrice * p.Quantity).Sum()).Sum();

            //j年份.男 = Od.Where(p => p.Members.Gender == "男").ToList().Count();
            //j年份.女 = Od.Where(p => p.Members.Gender == "女").ToList().Count();
            return ViewComponent("AnalysisTable",j年份);
        }
        public IActionResult BB()
        {
            return ViewComponent("AnalysisTable2");
        }
    }
}
