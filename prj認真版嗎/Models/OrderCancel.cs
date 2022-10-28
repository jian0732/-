using System;
using System.Collections.Generic;

#nullable disable

namespace prj認真版嗎.Models
{
    public partial class OrderCancel
    {
        public int OrderCancelId { get; set; }
        public string Titel { get; set; }
        public string CancaelContent { get; set; }
        public int OrderId { get; set; }

        public virtual Order Order { get; set; }
    }
}
