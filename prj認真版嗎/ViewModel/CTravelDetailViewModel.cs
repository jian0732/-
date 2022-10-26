using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace prj認真版嗎.ViewModel
{
    public class CTravelDetailViewModel
    {
        public int TravelProductDetailId { get; set; }
        public int TravelProductId { get; set; }
        public int Day { get; set; }
        [DisplayName("住宿地點")]
        public int? HotelId { get; set; }
        [DisplayName("日期")]
        public string Date { get; set; }
        [DisplayName("行程概述")]
        public string DailyDetailText { get; set; }
       
        public List<int> TrasportationID { get; set; }
        public List<int> ViewID { get; set; }
        public List<CreateView> _CreateView { get; set; }

    }
    public class CreateView {
        public string CreateViewName { get; set; }
        public int CreateViewCityID { get; set; }
    }

}
