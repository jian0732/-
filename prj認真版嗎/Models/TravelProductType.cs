using System;
using System.Collections.Generic;

#nullable disable

namespace prj認真版嗎.Models
{
    public partial class TravelProductType
    {
        public TravelProductType()
        {
            TravelProducts = new HashSet<TravelProduct>();
        }

        public int TravelProductTypeId { get; set; }
        public string TravelProductTypeName { get; set; }

        public virtual ICollection<TravelProduct> TravelProducts { get; set; }
    }
}
