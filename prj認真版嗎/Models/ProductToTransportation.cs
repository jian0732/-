﻿using System;
using System.Collections.Generic;

#nullable disable

namespace prj認真版嗎.Models
{
    public partial class ProductToTransportation
    {
        public int ProductToTransportationId { get; set; }
        public int TravelProductId { get; set; }
        public int TrasportationId { get; set; }

        public virtual Trasportation Trasportation { get; set; }
        public virtual TravelProduct TravelProduct { get; set; }
    }
}
