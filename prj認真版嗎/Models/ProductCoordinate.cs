using System;
using System.Collections.Generic;

#nullable disable

namespace prj認真版嗎.Models
{
    public partial class ProductCoordinate
    {
        public int ProductNameCoordinateId { get; set; }
        public int? TravelProductId { get; set; }
        public int? CoordinateId { get; set; }

        public virtual Coordinate Coordinate { get; set; }
        public virtual TravelProduct TravelProduct { get; set; }
    }
}
