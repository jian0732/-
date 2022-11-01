using prj認真版嗎.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace prj認真版嗎.MViewModel
{
    public class CCoupon
    {
        public CCoupon()
        {
            _co = new Coupon();
        }
        private Coupon _co;

        public Coupon coupon
        {
            get { return _co; }
            set { _co = value; }
        }
        public int CouponId
        {
            get { return _co.CouponId; }
            set { _co.CouponId = value; } 
        }
        public string GiftKey
        {
            get { return _co.GiftKey; }
            set { _co.GiftKey = value; }
        }
        public string CouponName
        {
            get { return _co.CouponName; }
            set { _co.CouponName = value; }
        }
        public decimal Discount
        {
            get { return _co.Discount; }
            set { _co.Discount = value; }
        }
        public string ExDate
        {
            get { return _co.ExDate; }
            set { _co.ExDate = value; }
        }
        public string Condition
        {
            get { return _co.Condition; }
            set { _co.Condition = value; }
        }
        public bool Useful
        {
            get { return _co.Useful; }
            set { _co.Useful = value; }
        }
        [DataType(DataType.Date)]
        public DateTime Expdate
        {
            get;
            set;
        }
    }
}
