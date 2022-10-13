using Microsoft.AspNetCore.Http;
using prj認真版嗎.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace prj認真版嗎.ViewModel
{
    public class CMember
    {
        public CMember()
        {
            _member = new Member();
        }
        private Member _member;
        public Member member
        {
            get { return _member; }
            set { _member = value; }
        }
        public int MembersId
        {
            get { return _member.MembersId; }
            set { _member.MembersId = value; }
        }
        [DisplayName("品名")]
        public string MemberName
        {
            get { return _member.MemberName; }
            set { _member.MemberName = value; }
        }
        [DisplayName("密碼")]
        public string Password
        {
            get { return _member.Password; }
            set { _member.Password = value; }
        }

        [DisplayName("電話")]
        public string Phone
        {
            get { return _member.Phone; }
            set { _member.Phone = value; }
        }
        [DisplayName("區")]
        public string Address
        {
            get { return _member.Address; }
            set { _member.Address = value; }
        }
        [DisplayName("電子郵件")]
        public string Email
        {
            get { return _member.Email; }
            set { _member.Email = value; }
        }
        [DisplayName("性別")]
        public string Gender
        {
            get { return _member.Gender; }
            set { _member.Gender = value; }
        }
        [DisplayName("生日")]
        public string BirthDay 
        {
            get { return _member.BirthDay; }
            set { _member.BirthDay = value; }
        }

        [DisplayName("相片")]
        public string PhotoPath
        {
            get { return _member.PhotoPath; }
            set { _member.PhotoPath = value; }
        }
        [DisplayName("狀態")]
        public int MemberStatusId
        {
            get { return _member.MemberStatusId; }
            set { _member.MemberStatusId = value; }
        }
        [DisplayName("縣市")]
        public int CityId
        {
            get { return _member.CityId; }
            set { _member.CityId = value; }
        }
        
        public string MemberStatusName { get; set; }     
        public string CityName { get; set; }
        public IFormFile photo { get; set; }
    }
}
