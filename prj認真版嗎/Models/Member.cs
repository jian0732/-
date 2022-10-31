﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace prj認真版嗎.Models
{
    public partial class Member
    {
        public Member()
        {
            Comments = new HashSet<Comment>();
            CouponLists = new HashSet<CouponList>();
            MemberMessages = new HashSet<MemberMessage>();
            Myfavorites = new HashSet<Myfavorite>();
            Orders = new HashSet<Order>();
        }

        public int MembersId { get; set; }
        public string MemberName { get; set; }
        public string Password { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        public string Gender { get; set; }
        public int CityId { get; set; }
        public string BirthDay { get; set; }
        public string PhotoPath { get; set; }
        public int MemberStatusId { get; set; }

        public virtual City City { get; set; }
        public virtual MemberStatus MemberStatus { get; set; }
        public virtual ICollection<Comment> Comments { get; set; }
        public virtual ICollection<CouponList> CouponLists { get; set; }
        public virtual ICollection<MemberMessage> MemberMessages { get; set; }
        public virtual ICollection<Myfavorite> Myfavorites { get; set; }
        public virtual ICollection<Order> Orders { get; set; }
    }
}
