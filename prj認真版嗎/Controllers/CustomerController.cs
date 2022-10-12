using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using prj認真版嗎.Models;
using prj認真版嗎.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace prj認真版嗎.Controllers
{
    public class CustomerController : Controller
    {
        private IWebHostEnvironment _enviro;
        private PlanetTravelContext _db;
        public CustomerController(IWebHostEnvironment p, PlanetTravelContext q)
        {
            _db = q;
            _enviro = p;
        }
        public IActionResult List()
        {
            List<CMember> qq = _db.Members.Select(s => new CMember
            {
                member=s,
                CityName = s.City.CityName,
                MemberStatusName = s.MemberStatus.MemberStatusName
            }).ToList();

            return View(qq);
        }

        //public ActionResult Delete(int? id)
        //{
        //    if (id != null)
        //    {
        //        Member prod = _db.Members.FirstOrDefault(p => p.MembersId == id);
        //        if (prod != null)
        //        {
        //            _db.Members.Remove(prod);
        //            _db.SaveChanges();
        //        }
        //    }
        //    return RedirectToAction("List");
        //}

        public ActionResult Edit(int? id)
        {
            if (id != null)
            {

                CMember prod = new CMember();
                prod.member= _db.Members.FirstOrDefault(p => p.MembersId == id);
                if (prod != null)
                {
                    return PartialView(prod);
                }
            }
            return RedirectToAction("List");
        }

        [HttpPost]
        public ActionResult Edit(CMember inPord)
        {
            Member prod = _db.Members.FirstOrDefault(p => p.MembersId == inPord.MembersId);
            if (prod != null)
            {
                //if (inPord.PhotoPath != null)
                //{
                //    string photoname = Guid.NewGuid().ToString() + ".jpg";
                //    inPord.PhotoPath.SaveAs(Server.MapPath("../../images/" + photoname));
                //    prod.fimagePath = photoname;
                //}
                prod.Email = inPord.Email;
                prod.MemberName = inPord.MemberName;
                prod.Password = inPord.Password;
                prod.Phone = inPord.Phone;
                prod.CityId = inPord.CityId;
                _db.SaveChanges();
            }
            return RedirectToAction("List");
        }
    }
}
