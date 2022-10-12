﻿using System;
using System.Collections.Generic;

#nullable disable

namespace prj認真版嗎.Models
{
    public partial class Coupon
    {
        public Coupon()
        {
            OrderDetails = new HashSet<OrderDetail>();
        }

        public int CouponId { get; set; }
        public string CouponName { get; set; }
        public decimal Discount { get; set; }
        public string Photo { get; set; }

        public virtual ICollection<OrderDetail> OrderDetails { get; set; }
    }
}
