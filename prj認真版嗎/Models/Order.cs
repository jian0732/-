using System;
using System.Collections.Generic;

#nullable disable

namespace prj認真版嗎.Models
{
    public partial class Order
    {
        public Order()
        {
            OrderCancels = new HashSet<OrderCancel>();
            OrderDetails = new HashSet<OrderDetail>();
        }

        public int OrderId { get; set; }
        public int MembersId { get; set; }
        public int PaymentId { get; set; }
        public string OrderDate { get; set; }
        public int OrderStatusId { get; set; }
        public int? CouponId { get; set; }

        public virtual Coupon Coupon { get; set; }
        public virtual Member Members { get; set; }
        public virtual OrderStatus OrderStatus { get; set; }
        public virtual Payment Payment { get; set; }
        public virtual ICollection<OrderCancel> OrderCancels { get; set; }
        public virtual ICollection<OrderDetail> OrderDetails { get; set; }
    }
}
