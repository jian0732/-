using Microsoft.AspNetCore.Mvc;
using prj認真版嗎.Models;
using prj認真版嗎.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace prj認真版嗎.Controllers
{
    public class AdminController : Controller
    {
        private PlanetTravelContext _db;

        public AdminController(PlanetTravelContext q)
        {
            _db = q;
        }
        // GET: Admin
        public ActionResult List()
        {
            List<CAdminViewModel> qq = _db.Admins.Select(s => new CAdminViewModel
            {
                admin = s,
                CommentStatus = s.AdminStatuses.Select(s => s.CommentStatus).FirstOrDefault(),
                MemberStatus = s.AdminStatuses.Select(s => s.MemberStatus).FirstOrDefault(),
                AdminStatus1 = s.AdminStatuses.Select(s => s.AdminStatus1).FirstOrDefault(),
                ProductStatus = s.AdminStatuses.Select(s => s.ProductStatus).FirstOrDefault(),
            }).ToList();
            
            return View(qq);
        }
        public ActionResult ttry()
        {
            List<CAdminViewModel> qq = _db.Admins.Select(s => new CAdminViewModel
            {
                admin = s,
                CommentStatus = s.AdminStatuses.Select(s => s.CommentStatus).FirstOrDefault(),
                MemberStatus = s.AdminStatuses.Select(s => s.MemberStatus).FirstOrDefault(),
                AdminStatus1 = s.AdminStatuses.Select(s => s.AdminStatus1).FirstOrDefault(),
                ProductStatus = s.AdminStatuses.Select(s => s.ProductStatus).FirstOrDefault(),
            }).ToList();

            return Json(qq);
        }
        public IActionResult Create()
        {
            return View();
        }
        public IActionResult Cy(string Account)
        {
            Admin A = _db.Admins.FirstOrDefault(p => p.Account == Account);
            if(A != null)
                return Content("此帳號已存在", "text/plain", System.Text.Encoding.UTF8);
            else
                return Content("此帳號可以使用", "text/plain", System.Text.Encoding.UTF8);
        }

        [HttpPost]
        public IActionResult Create(Admin ad, CAdminViewModel Vad)
        {
            _db.Admins.Add(ad);
            _db.SaveChanges();
            _db.AdminStatuses.Add(new AdminStatus()
            {
                AdminId = ad.AdminId,
                AdminStatus1 = Vad.AdminStatus1,
                CommentStatus = Vad.CommentStatus,
                MemberStatus = Vad.MemberStatus,
                ProductStatus = Vad.ProductStatus,
            });
            _db.SaveChanges();
            return RedirectToAction("List");
        }
        public IActionResult Edit(int? id)
        {
            CAdminViewModel qq = _db.Admins.Where(p=>p.AdminId==id).Select(s => new CAdminViewModel
            {
                admin = s,
                CommentStatus = s.AdminStatuses.Select(s => s.CommentStatus).FirstOrDefault(),
                MemberStatus = s.AdminStatuses.Select(s => s.MemberStatus).FirstOrDefault(),
                AdminStatus1 = s.AdminStatuses.Select(s => s.AdminStatus1).FirstOrDefault(),
                ProductStatus = s.AdminStatuses.Select(s => s.ProductStatus).FirstOrDefault(),
            }).FirstOrDefault();

            return View(qq);
        }
        [HttpPost]
        public IActionResult Edit(CAdminViewModel adm)
        {
            Admin A管理員 = _db.Admins.FirstOrDefault(p => p.AdminId == adm.AdminId);
            if(A管理員 != null)
            {
                A管理員.AdminName = adm.AdminName;
                A管理員.Password = adm.Password;
                A管理員.Account = adm.Account;
                _db.SaveChanges();

             AdminStatus AdS = _db.AdminStatuses.FirstOrDefault(p => p.AdminId == adm.AdminId);
             AdS.CommentStatus = adm.CommentStatus;
             AdS.MemberStatus = adm.MemberStatus;
             AdS.AdminStatus1 = adm.AdminStatus1;
             AdS.ProductStatus = adm.ProductStatus;
             _db.SaveChanges();
            }
            return RedirectToAction("List");
        }
        public IActionResult Delete(int? id)
        {
            AdminStatus AdS = _db.AdminStatuses.FirstOrDefault(p => p.AdminId == id);
            if(AdS != null)
            _db.AdminStatuses.Remove(AdS);
            _db.SaveChanges();
            Admin A管理員 = _db.Admins.FirstOrDefault(p => p.AdminId == id);
            _db.Admins.Remove(A管理員);
            _db.SaveChanges();
            return RedirectToAction("List");
        }
    }
}
