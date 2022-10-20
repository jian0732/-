using Microsoft.AspNetCore.Mvc;
using prj認真版嗎.Models;
using prj認真版嗎.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace prj認真版嗎.Controllers
{
    public class OrderController : Controller
    {

        public OrderController(PlanetTravelContext db)
        {
            _db = db;
            _db.Coupons.ToList();
            _db.OrderDetails.ToList();
        }
        private PlanetTravelContext _db;
        public IActionResult List()
        {
            List<COrderViewModel> datas = null;
            datas = _db.Orders.Select(s => new COrderViewModel
            {
                order = s,
                會員名稱 = s.Members.MemberName,
                訂單狀態 = s.OrderStatus.OrderStatusName,
                付款方式 = s.Payment.PaymentName,
            }).ToList();
            return View(datas);
        }
        public ActionResult OrderDetail(int id)
        {
            List<COrederDetailsViewModel> datas = null;
            datas = _db.OrderDetails.Where(p => p.OrderId == id)
                .Select(s => new COrederDetailsViewModel
                {
                    orderdetail = s,
                    優惠券名稱 = s.Coupon.CouponName,
                    優惠內容 = s.Coupon.Discount,
                    產品名稱 = s.TravelProduct.TravelProductName,

                }).ToList();
            return View(datas);


            //return RedirectToAction("List");
        }
    }
}
