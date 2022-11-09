using System;
using System.Collections.Generic;

#nullable disable

namespace prj認真版嗎.Models
{
    public partial class TProduct
    {
        public int Fid { get; set; }
        public string FName { get; set; }
        public decimal? FCost { get; set; }
        public int? FQty { get; set; }
        public decimal? FPrice { get; set; }
        public byte[] Fimage { get; set; }
        public string FimagePath { get; set; }
    }
}
