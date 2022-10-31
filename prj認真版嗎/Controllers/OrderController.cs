using Microsoft.AspNetCore.Mvc;
using prj認真版嗎.Authorization;
using prj認真版嗎.Models;
using prj認真版嗎.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace prj認真版嗎.Controllers
{
    [AuthorizationManeger]
    public class OrderController : Controller
    {

        public OrderController(PlanetTravelContext db)
        {
            _db = db;
            _db.Coupons.ToList();
            _db.OrderDetails.ToList();
            _db.Orders.ToList();
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

        public ActionResult OrderDetail(int? id)
        {
           
            List<COrederDetailsViewModel> datas = null;
            var q = _db.OrderDetails.Where(p => p.OrderId == id).ToList();
            if (id != null)
            {
                datas = _db.OrderDetails.Where(p => p.OrderId == id)
                    .Select(s => new COrederDetailsViewModel
                    {
                        orderdetail = s,
                        優惠券名稱 = s.Order.Coupon.CouponName,
                        優惠內容 = s.Order.Coupon.Discount,
                        產品名稱 = s.TravelProduct.TravelProductName,
                    }).ToList();
                
                var CCid = _db.Orders.FirstOrDefault(p=>p.OrderId==id&& p.OrderStatusId==4);
                ViewBag.CCid = CCid;
                if (CCid != null)
                {
                    
                    ViewBag.取消理由 = _db.OrderCancels.FirstOrDefault(p => p.OrderId == id).Titel;
                    ViewBag.詳細說明 = _db.OrderCancels.FirstOrDefault(p => p.OrderId == id).CancaelContent;
                }
                return View(datas);
            }

            return RedirectToAction("List");
        }

        public IActionResult Edit(int? id)
        {
            COrderViewModel qq = _db.Orders.Where(p => p.OrderId == id).Select(s => new COrderViewModel
            {
                order = s,
                會員名稱 = s.Members.MemberName,
                訂單狀態 = s.OrderStatus.OrderStatusName,
                付款方式 = s.Payment.PaymentName,
            }).FirstOrDefault();

            return View(qq);
        }
        [HttpPost]
        public IActionResult Edit(COrderViewModel adm)
        {
            Order od = _db.Orders.FirstOrDefault(p => p.OrderId == adm.OrderId);
            var ods = _db.OrderStatuses.ToList();
            var pay = _db.Payments.ToList();
            if (od != null)
            {
                od.OrderStatusId = ods.FirstOrDefault(a => a.OrderStatusName == adm.訂單狀態).OrderStatusId;
                od.PaymentId = pay.FirstOrDefault(a => a.PaymentName == adm.付款方式).PaymentId;
                _db.SaveChanges();
            }
            return RedirectToAction("List");
        }

        public IActionResult Status(int id)
        {

            var Status = _db.Payments.Where(p => p.PaymentId != id).Select(p => p.PaymentName);

            return Json(Status);
        }
        public IActionResult OStatus(int id)
        {

            var Status = _db.OrderStatuses.Where(p => p.OrderStatusId != id).Select(p => p.OrderStatusName);

            return Json(Status);
        }
        public IActionResult EditStatus(COrderEditStatus id)
        {
            Order order = null;

            if (id.Orderkey != null)
            {
                var Orders = _db.Orders.ToList();
                foreach (var i in id.Orderkey)
                {
                    order = Orders.FirstOrDefault(p => p.OrderId == i);
                    order.OrderStatusId = 3;

                }
                _db.SaveChanges();
            }
            return RedirectToAction("List");
        }

        public IActionResult showreply(int? id)
        {
            if (id != null)
            {
                var data = _db.OrderCancels.FirstOrDefault(p=>p.OrderId==(int)id);
                return View(data);
            }
            return RedirectToAction("List");
        }
        [HttpPost]
        public IActionResult showreply(OrderCancel data)
        {
            if (data != null)
            {
                var q = _db.Orders.FirstOrDefault(p => p.OrderId == data.OrderId);
                q.OrderStatusId = 4;
                _db.SaveChanges();
            }
            return RedirectToAction("List");
        }
    }
}
