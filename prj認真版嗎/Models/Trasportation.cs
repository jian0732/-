using System;
using System.Collections.Generic;

#nullable disable

namespace prj認真版嗎.Models
{
    public partial class Trasportation
    {
        public Trasportation()
        {
            ProductToTransportations = new HashSet<ProductToTransportation>();
        }

        public int TrasportationId { get; set; }
        public string TrasportationName { get; set; }

        public virtual ICollection<ProductToTransportation> ProductToTransportations { get; set; }
    }
}
