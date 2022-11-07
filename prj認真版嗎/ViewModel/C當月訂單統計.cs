using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace prj認真版嗎.ViewModel
{
    public class C當月訂單統計
    {
        public string 訂單日期 { get; set; }
        public int 產品編號 { get; set; }
        public string 旅遊地區 { get; set; }
        public decimal 金額  { get; set; }

        public string 國家 { get; set; }
        public int 訂單量 { get; set; }

        public int 產品編號最多 { get; set; }
        public int 產品編號最多訂單量 { get; set; }

    }    
}
