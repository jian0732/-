using System;
using System.Collections.Generic;

#nullable disable

namespace prj認真版嗎.Models
{
    public partial class View
    {
        public View()
        {
            ProductToViews = new HashSet<ProductToView>();
        }

        public int ViewId { get; set; }
        public string ViewName { get; set; }
        public int CityId { get; set; }

        public virtual City City { get; set; }
        public virtual ICollection<ProductToView> ProductToViews { get; set; }
    }
}
