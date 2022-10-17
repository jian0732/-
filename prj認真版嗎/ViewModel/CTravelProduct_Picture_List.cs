using prj認真版嗎.Models;
using System.Collections.Generic;
using System.ComponentModel;

namespace prj認真版嗎.ViewModel
{
    public class CTravelProduct_Picture_List
    {
        public List<產品格式> 產品列表;
        //public List<TravelProduct> pro { get; set; }
    }
    public class 產品格式
    {
        public int TravelPictureId { get; set; }
        [DisplayName("預覽圖片")]
        public string TravelPicture1 { get; set; }
        public string TravelPictureText { get; set; }
        public int TravelProductId { get; set; }
        [DisplayName("行程名稱")]
        public string TravelProductName { get; set; }
        public decimal Price { get; set; }
        public int TravelProductTypeId { get; set; }
        public int Stocks { get; set; }
        public string Description { get; set; }
        public int CountryId { get; set; }
        public int Cost { get; set; }
        public string EventIntroduction { get; set; }
        public string PreparationDescription { get; set; }

    }

    


}