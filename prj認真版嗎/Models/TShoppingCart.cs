using System;
using System.Collections.Generic;

#nullable disable

namespace prj認真版嗎.Models
{
    public partial class TShoppingCart
    {
        public int Fid { get; set; }
        public string FDate { get; set; }
        public int? FCustomer { get; set; }
        public int? FProduct { get; set; }
        public int? TCount { get; set; }
        public decimal? TPrice { get; set; }
    }
}
