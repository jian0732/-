using System;
using System.Collections.Generic;

#nullable disable

namespace prj認真版嗎.Models
{
    public partial class Coupon
    {
        public Coupon()
        {
            Members = new HashSet<Member>();
            OrderDetails = new HashSet<OrderDetail>();
        }

        public int CouponId { get; set; }
        public string CouponName { get; set; }
        public decimal Discount { get; set; }
        public string ExDate { get; set; }
        public string Condition { get; set; }

        public virtual ICollection<Member> Members { get; set; }
        public virtual ICollection<OrderDetail> OrderDetails { get; set; }
    }
}
