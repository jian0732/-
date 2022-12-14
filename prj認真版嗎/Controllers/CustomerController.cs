using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using prjMvcCoreModel.ViewModel;
using prj認真版嗎.Authorization;
using prj認真版嗎.Models;
using prj認真版嗎.ViewModel;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace prj認真版嗎.Controllers
{
    [AuthorizationManeger]
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
            List<CMember> datas = null;
            datas = _db.Members.Select(s => new CMember
            {
                member = s,
                CityName = s.City.CityName,
                MemberStatusName = s.MemberStatus.MemberStatusName
            }).ToList();
            return View(datas);
            //if (string.IsNullOrEmpty(keyword.txtKeyword))
            //{

            //}
            //else
            //{
            //    datas = _db.Members.Where
            //    (a => a.Address.Contains(keyword.txtKeyword) || a.Email.Contains(keyword.txtKeyword) ||
            //    a.MemberName.Contains(keyword.txtKeyword) || a.BirthDay.Contains(keyword.txtKeyword) ||
            //    a.Gender.Contains(keyword.txtKeyword) || a.MemberStatus.MemberStatusName.Contains(keyword.txtKeyword))
            //     .Select(s => new CMember
            //     {
            //         member = s,
            //         CityName = s.City.CityName,
            //         MemberStatusName = s.MemberStatus.MemberStatusName
            //     }).ToList();
            //    if (datas.Count == 0)
            //    {
            //        datas.Add(new CMember() { MemberName = "查無相關資料" });
            //    }
            //}
            //return View(datas);

        }

        public IActionResult Create()
        {
            return PartialView();
        }
        //[HttpPost]
        //public ActionResult Create(CProductViewModel p)
        //{
        //    _db.Admins.Add(ad);
        //    _db.SaveChanges();
        //    _db.AdminStatuses.Add(new AdminStatus()
        //    {
        //        AdminId = ad.AdminId,
        //        AdminStatus1 = Vad.AdminStatus1,
        //        CommentStatus = Vad.CommentStatus,
        //        MemberStatus = Vad.MemberStatus,
        //        ProductStatus = Vad.ProductStatus,
        //    });
        //    _db.SaveChanges();
        //    return RedirectToAction("Index");
        //}
        public ActionResult Delete(int? id)
        {
            if (id != null)
            {
                Member prod = _db.Members.FirstOrDefault(p => p.MembersId == id);
                if (prod != null)
                {
                    _db.Members.Remove(prod);
                    _db.SaveChanges();
                }
            }
            return RedirectToAction("List");
        }

        public ActionResult Edit(int? id)
        {
            if (id != null)
            {
                CMember qq = _db.Members.Where(p => p.MembersId == id).Select(s => new CMember
                {
                    member = s,
                    CityName = s.City.CityName,
                    MemberStatusName = s.MemberStatus.MemberStatusName
                }).FirstOrDefault();
                return View(qq);
            }
            return RedirectToAction("List");
        }

        [HttpPost]
        public ActionResult Edit(CMember inPord)
        {
            Member prod = _db.Members.FirstOrDefault(p => p.MembersId == inPord.MembersId);
            if (prod != null)
            {
                if (inPord.photo != null)
                {
                    string photoname = Guid.NewGuid().ToString() + ".jpg";
                    prod.PhotoPath = photoname;
                    //string path = _enviro.WebRootPath + "/images/" + photoname;
                    string path = "https://localhost:44302/images/客戶大頭貼/" + photoname;
                    inPord.photo.CopyTo(new FileStream(path, FileMode.Create));

                }
                prod.BirthDay = inPord.BirthDay;
                prod.Address = inPord.Address;
                prod.Email = inPord.Email;
                prod.MemberName = inPord.MemberName;
                prod.Password = inPord.Password;
                prod.Phone = inPord.Phone;
                prod.Gender = inPord.Gender;
                prod.CityId = _db.Cities.FirstOrDefault(p => p.CityName == inPord.CityName).CityId;
                prod.MemberStatusId = _db.MemberStatuses.FirstOrDefault(p => p.MemberStatusName == inPord.MemberStatusName).MemberStatusId;
                _db.SaveChanges();
            }
            return RedirectToAction("List");
        }
        public IActionResult Status(int id)
        {

            var Status = _db.MemberStatuses.Where(p => p.MemberStatusId != id).Select(p => p.MemberStatusName);

            return Json(Status);
        }
    }
}
