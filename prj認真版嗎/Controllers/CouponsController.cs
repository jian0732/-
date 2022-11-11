using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using prj認真版嗎.Authorization;
using prj認真版嗎.Models;
using prj認真版嗎.MViewModel;

namespace prj認真版嗎.Controllers
{
    [AuthorizationManeger]
    public class CouponsController : Controller
    {
        private readonly PlanetTravelContext _context;

        public CouponsController(PlanetTravelContext context)
        {
            _context = context;
        }

        // GET: Coupons
        public async Task<IActionResult> Index()
        {

            _context.Coupons.ToList();
            var q = _context.Coupons.Select(a => a.CouponId).ToList();
            var 日期 = DateTime.Now.ToShortDateString();
            foreach (var item in _context.Coupons)
            {
                if (DateTime.Parse(item.ExDate) < DateTime.Parse(日期))
                {
                    item.Useful= false;
                }

            }
         
            return View(await _context.Coupons.ToListAsync());
        }

        // GET: Coupons/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var coupon = await _context.Coupons
                .FirstOrDefaultAsync(m => m.CouponId == id);
            if (coupon == null)
            {
                return NotFound();
            }

            return View(coupon);
        }

        // GET: Coupons/Create
        public IActionResult Create()
        {
            return View();
        }

       
        [HttpPost]
        public IActionResult Create(CCoupon cou)
        {
           
                Coupon cc = new Coupon();
                cc.CouponName = cou.CouponName;
                cc.Discount = cou.Discount;
                cc.ExDate = cou.Expdate.ToString("yyyy/MM/dd");
                cc.GiftKey = cou.GiftKey;
                cc.Condition = cou.Condition;
                cc.Useful = true;
                _context.Coupons.Add(cc);
                 _context.SaveChanges();
                return RedirectToAction("Index");
         
        }

        // GET: Coupons/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
     

            var coupon = await _context.Coupons.FindAsync(id);
            
            Coupon cou = new Coupon();
            CCoupon aa = new CCoupon();
            aa = (from s in _context.Coupons.Where(a => a.CouponId == id)
                         select new CCoupon
                         {
                            CouponId=s.CouponId,
                            CouponName=s.CouponName,
                            Expdate=Convert.ToDateTime(s.ExDate),
                            Condition=s.Condition,
                            Useful=(bool)s.Useful,
                            Discount=s.Discount,
                            GiftKey=s.GiftKey
                         }
                       ).FirstOrDefault();
           
            return View(aa);
        }

       

          
        //[ValidateAntiForgeryToken]
        [HttpPost]
        public IActionResult Edit(CCoupon coc)
        {
            if (coc != null)
            {

                var a = _context.Coupons.FirstOrDefault(a => a.CouponId == coc.CouponId);
                a.ExDate= coc.Expdate.ToString("yyyy/MM/dd");
                a.Useful = coc.Useful;
                a.CouponName = coc.CouponName;
                a.GiftKey=coc.GiftKey;
                
            }
            _context.SaveChanges();
       
            return RedirectToAction("Index");
        }

        // GET: Coupons/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var coupon = await _context.Coupons
                .FirstOrDefaultAsync(m => m.CouponId == id);
            if (coupon == null)
            {
                return NotFound();
            }

            return View(coupon);
        }

        // POST: Coupons/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var coupon = await _context.Coupons.FindAsync(id);
            _context.Coupons.Remove(coupon);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CouponExists(int id)
        {
            return _context.Coupons.Any(e => e.CouponId == id);
        }
    }
}
