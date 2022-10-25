using Microsoft.AspNetCore.Mvc;
using prj認真版嗎.Models;
using prj認真版嗎.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace prj認真版嗎.Controllers
{
    public class CommentController : Controller
    {
        public CommentController(PlanetTravelContext _PTdb)
        {
            _db = _PTdb;
        }
        private PlanetTravelContext _db;

        public IActionResult List()
        {
            List<C評論畫面> com = null;
            com = _db.Comments.OrderByDescending(o=>o.CommentDate).Select(s=>new C評論畫面 
            {
             comment=s,
             產品名稱=s.TravelProduct.TravelProductName
            }).ToList();
            
            return View(com);
        }
        public IActionResult Showcomment(int id)
        {
            C評論畫面 com = null;
            com = _db.Comments.Where(p=>p.CommentId==id).Select(s => new C評論畫面
            {
                comment = s,
                產品名稱 = s.TravelProduct.TravelProductName,
                會員名稱=s.Members.MemberName
            }).FirstOrDefault();

            return ViewComponent("Commentdata", com);
        }

        public IActionResult offs(int id)
        {
            C評論畫面 com = null;

            var q = _db.Comments.FirstOrDefault(p => p.CommentId == id);
            q.CommentStatus = false;
            _db.SaveChanges();

            com = _db.Comments.Where(p => p.CommentId == id).Select(s => new C評論畫面
            {
                comment = s,
                產品名稱 = s.TravelProduct.TravelProductName,
                會員名稱 = s.Members.MemberName
            }).FirstOrDefault();

            return ViewComponent("Commentdata", com);

        }
        public IActionResult opens(int id)
        {
            C評論畫面 com = null;

            var q = _db.Comments.FirstOrDefault(p => p.CommentId == id);
            q.CommentStatus = true;
            _db.SaveChanges();

            com = _db.Comments.Where(p => p.CommentId == id).Select(s => new C評論畫面
            {
                comment = s,
                產品名稱 = s.TravelProduct.TravelProductName,
                會員名稱 = s.Members.MemberName
            }).FirstOrDefault();

            return ViewComponent("Commentdata", com);
        }
    }
}
