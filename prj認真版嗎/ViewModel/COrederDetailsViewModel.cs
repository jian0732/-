using prj認真版嗎.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace prj認真版嗎.ViewModel
{
    public class COrederDetailsViewModel
    {
        public COrederDetailsViewModel()
        {
            _ord = new OrderDetail();
        }
        private OrderDetail _ord;

        public OrderDetail orderdetail
        {
            get { return _ord; }
            set { _ord =value; }
        }
        public int OrderDetailId
        {
            get { return _ord.OrderDetailId; }
            set { _ord.OrderDetailId = value; }
        }
        public int? OrderId
        {
            get { return _ord.OrderId; }
            set { _ord.OrderId = value; }
        }
        public int TravelProductId
        {
            get { return _ord.TravelProductId; }
            set { _ord.TravelProductId = value; }
        }
        [DisplayName("單價")]
        public decimal UnitPrice
        {
            get { return _ord.UnitPrice; }
            set { _ord.UnitPrice = value; }
        }
        [DisplayName("數量")]
        public int Quantity
        {
            get { return _ord.Quantity; }
            set { _ord.Quantity = value; }
        }
        public int? CouponId
        {
            get { return _ord.CouponId; }
            set { _ord.CouponId = value; }
        }
        public string 產品名稱 { get; set; }
        public string 優惠券名稱 { get; set; }
        public decimal 優惠內容 { get; set; }
        public decimal 小計 { get { return this.Quantity * this.UnitPrice; } }
    }
}
