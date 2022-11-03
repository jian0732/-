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
            _Trasportation = new Trasportation();            

        }

        private TravelProduct _product;
        public List<CTravelDetailViewModel> _TravelProductDetail { get; set; }        
        private Trasportation _Trasportation;
        public List<View> _View;
        //public List<ProductToTransportation> _ProductToTransportation { get; set; }


        public TravelProduct product
        {
            get { return _product; }
            set { _product = value; }
        }

        public List<IFormFile> photo { get; set; } //圖片的檔案
        public string TravelPicturePath //圖片的路徑
        {
            get;
            set;
        }
        [DisplayName("圖片集描述")]
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
        [DisplayName("行程分類")]
        public int TravelProductTypeId
        {
            get { return (int)_product.TravelProductTypeId; }
            set { _product.TravelProductTypeId = value; }
        }
        [DisplayName("行程總人數")]
        public int Stocks
        {
            get { return _product.Stocks; }
            set { _product.Stocks = value; }
        }
        [DisplayName("行程簡介")]
        public string Description
        {
            get { return _product.Description; }
            set { _product.Description = value; }
        }
        [DisplayName("旅遊國家")]
        public int CountryId
        {
            get { return _product.CountryId; }
            set { _product.CountryId = value; }
        }
        [DisplayName("每人成本")]
        public int Cost
        {
            get { return _product.Cost; }
            set { _product.Cost = value; }
        }
        [DisplayName("活動介紹")]
        public string EventIntroduction
        {
            get { return _product.EventIntroduction; }
            set { _product.EventIntroduction = value; }
        }
        [DisplayName("行前準備注意事項")]
        public string PreparationDescription
        {
            get { return _product.PreparationDescription; }
            set { _product.PreparationDescription = value; }
        }
        [DisplayName("Google地圖連結")]
        public string MapUrl
        {
            get { return _product.MapUrl; }
            set { _product.MapUrl = value; }
        }
        [DisplayName("其他行程出團日")]
        public string AnotherDepartureDate
        {
            get { return _product.AnotherDepartureDate; }
            set { _product.AnotherDepartureDate = value; }
        }

        //Trasportation屬性欄位
        //public List<int> TrasportationID { get; set; }


    }
}
