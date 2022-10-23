using Microsoft.AspNetCore.Http;
using prj認真版嗎.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace prj認真版嗎.ViewModel
{
    public class CCreateTravelProductViewModel
    {
        public CCreateTravelProductViewModel()
        {
            _product = new TravelProduct();
            _TravelProductDetail = new TravelProductDetail();
            //_View = new View();
            _Trasportation = new Trasportation();         

    }
        private TravelProduct _product;
        private TravelProductDetail _TravelProductDetail;        
        private Trasportation _Trasportation;
        public List<View> _View;

        public TravelProduct product
        {
            get { return _product; }
            set { _product = value; }
        }
        public TravelProductDetail TravelProductDetail
        {
            get { return _TravelProductDetail; }
            set { _TravelProductDetail = value; }
        }
        public List<IFormFile> photo { get; set; } //圖片的檔案
        public string TravelPicturePath //圖片的路徑
        {
            get;
            set;
        }
        public string TravelPictureText //圖片描述
        {
            get;
            set;
        }

        public int TravelProductId
        {
            get { return _product.TravelProductId; }
            set { _product.TravelProductId = value; }
        }
        [DisplayName("行程方案名稱")]
        public string TravelProductName
        {
            get { return _product.TravelProductName; }
            set { _product.TravelProductName = value; }
        }

        [DisplayName("單價")]
        public decimal Price
        {
            get { return _product.Price; }
            set { _product.Price = value; }
        }
        public int TravelProductTypeId
        {
            get { return _product.TravelProductTypeId; }
            set { _product.TravelProductTypeId = value; }
        }
        public int Stocks
        {
            get { return _product.Stocks; }
            set { _product.Stocks = value; }
        }
        public string Description
        {
            get { return _product.Description; }
            set { _product.Description = value; }
        }
        public int CountryId
        {
            get { return _product.CountryId; }
            set { _product.CountryId = value; }
        }
        [DisplayName("成本")]
        public int Cost
        {
            get { return _product.Cost; }
            set { _product.Cost = value; }
        }
        public string EventIntroduction
        {
            get { return _product.EventIntroduction; }
            set { _product.EventIntroduction = value; }
        }

        public string PreparationDescription
        {
            get { return _product.PreparationDescription; }
            set { _product.PreparationDescription = value; }
        }

        public string MapUrl
        {
            get { return _product.MapUrl; }
            set { _product.MapUrl = value; }
        }
        //ProductDetail屬性欄位
        public int TravelProductDetailID
        {
            get { return _TravelProductDetail.TravelProductDetailId; }
            set { _TravelProductDetail.TravelProductDetailId = value; }
        }
        public int TravelProductDetail_ProductID
        {
            get { return _TravelProductDetail.TravelProductId; }
            set { _TravelProductDetail.TravelProductId = value; }
        }
        [Required(ErrorMessage = "請輸入數字")]
        public int Day
        {            
            get { return _TravelProductDetail.Day; }
            set { _TravelProductDetail.Day = value; }
        }
        public int TravelProductDetail_HotelID
        {
            get { return (int)_TravelProductDetail.HotelId; }
            set { _TravelProductDetail.HotelId = value; }
        }
        //public string TravelProductDetail_DisplayHotelName //展示的旅館名稱
        //{
        //    get;
        //    set;
        //}
        public string Date
        {
            get { return _TravelProductDetail.Date; }
            set { _TravelProductDetail.Date = value; }
        }
        public string DailyDetailText
        {
            get { return _TravelProductDetail.DailyDetailText; }
            set { _TravelProductDetail.DailyDetailText = value; }
        }
        //View屬性欄位
        //public int View_ViewID
        //{
        //    get { return _View.ViewId; }
        //    set { _View.ViewId = value; }
        //}
        //public int View_CityId
        //{
        //    get { return _View.CityId; }
        //    set { _View.CityId = value; }
        //}
        //public string ViewName
        //{
        //    get { return _View.ViewName; }
        //    set { _View.ViewName = value; }
        //}
        //Trasportation屬性欄位
        public int Trasportation_TrasportationID
        {
            get { return _Trasportation.TrasportationId; }
            set { _Trasportation.TrasportationId = value; }
        }
       
    }
}
