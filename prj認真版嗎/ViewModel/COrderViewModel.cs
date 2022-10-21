using prj認真版嗎.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace prj認真版嗎.ViewModel
{
    public class COrderViewModel
    {
        public COrderViewModel()
        {
            _order = new Order();
        }
        private Order _order;
        public Order order 
        { get {return _order; }
          set {_order =value; } 
        }
        [DisplayName("訂單編號")]
        public int OrderId
        {
            get { return _order.OrderId; }
            set { _order.OrderId = value; }
        }
        [DisplayName("會員編號")]
        public int MembersId
        {
            get { return _order.MembersId; }
            set { _order.MembersId = value; }
        }
        [DisplayName("付款方式")]
        public int PaymentId
        {
            get { return _order.PaymentId; }
            set { _order.PaymentId = value; }
        }

        [DisplayName("訂單日期")]
        public string OrderDate
        {
            get { return _order.OrderDate; }
            set { _order.OrderDate = value; }
        }
        [DisplayName("訂單狀態")]
        public int OrderStatusId
        {
            get { return _order.OrderStatusId; }
            set { _order.OrderStatusId = value; }
        }

        public string 會員名稱 { get; set; }

        public string 付款方式 { get; set; }

        public string 訂單狀態 { get; set; }
    }
}
