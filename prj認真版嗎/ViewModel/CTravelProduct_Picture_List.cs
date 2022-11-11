using prj認真版嗎.Models;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace prj認真版嗎.ViewModel
{
    public class CTravelProduct_Picture_List
    {
        public List<產品格式> 產品列表;        
    }
    public class 產品格式
    {
        public int TravelProductId { get; set; }
        public int TravelPictureId { get; set; }
        [DisplayName("預覽圖片")]
        public string TravelPicture1 { get; set; }
        [DisplayName("圖片描述")]
        public string TravelPictureText { get; set; }
        
        [DisplayName("行程名稱")]
        public string TravelProductName { get; set; }
        [DisplayName("每人行程價格")]
        [DisplayFormat(DataFormatString = "{0:C0}")]
        public decimal Price { get; set; }
        [DisplayName("行程類型")]
        public int TravelProductTypeId { get; set; }
        [DisplayName("行程類型")]
        public string TravelProductTypeDisplayName { get; set; }
        [DisplayName("行程天數")]
        public int TravelProductDaysDisplay { get; set; }
        [DisplayName("庫存")]
        public int Stocks { get; set; }
        [DisplayName("行程簡介")]
        public string Description { get; set; }
        [DisplayName("目的地國家")]
        public int CountryId { get; set; }
        [DisplayName("目的地國家")]
        public string CountryDisplayName { get; set; }
        [DisplayName("每人行程成本")]
        public int Cost { get; set; }
        [DisplayName("活動介紹")]
        public string EventIntroduction { get; set; }
        [DisplayName("活動注意事項")]
        public string PreparationDescription { get; set; }
        [DisplayName("產品狀態")]
        public string ProductStatus { get; set; }
       
    }

    


}