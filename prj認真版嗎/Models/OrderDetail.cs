using System;
using System.Collections.Generic;

#nullable disable

namespace prj認真版嗎.Models
{
    public partial class OrderDetail
    {
        public int OrderDetailId { get; set; }
        public int OrderId { get; set; }
        public int TravelProductId { get; set; }
        public decimal UnitPrice { get; set; }
        public int Quantity { get; set; }
        public string AccompanyPeople { get; set; }

        public virtual Order Order { get; set; }
        public virtual TravelProduct TravelProduct { get; set; }
    }
}
