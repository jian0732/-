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
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CouponId,GiftKey,CouponName,Discount,ExDate,Condition,GetDate")] Coupon coupon)
        {
            if (ModelState.IsValid)
            {
                _context.Add(coupon);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(coupon);
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
                            Expdate=DateTime.Parse(s.ExDate),
                            Condition=s.Condition,
                            Useful=s.Useful,
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
                a.ExDate= Convert.ToString(coc.Expdate);
                a.Useful = coc.Useful;
                
            }
            _context.SaveChanges();
       
            return Json(new {Res=true});
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
