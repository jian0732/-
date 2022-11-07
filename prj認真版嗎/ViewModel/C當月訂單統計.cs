using prj認真版嗎.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace prj認真版嗎.ViewModel
{
    public class C當月訂單統計
    {
        public List<OrderDetail> 訂單明細 { get; set; }
        public string 訂單日期 { get; set; }
        public int 訂單編號 { get; set; }
       
        public decimal 金額  { get; set; }

        public string 國家 { get; set; }
        public int 訂單量 { get; set; }

        public int 產品編號最多 { get; set; }
        public string 產品名稱 { get; set; }
        public int 產品編號最多訂單量 { get; set; }

        public List<C當月訂單統計> 產編訂單量 { get; set; }
        public List<C當月訂單統計> 國家訂單量 { get; set; }

    }    
}
