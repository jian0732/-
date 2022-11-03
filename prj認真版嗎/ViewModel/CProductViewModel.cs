using Microsoft.AspNetCore.Http;
using prj認真版嗎.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace prj認真版嗎.ViewModel
{
    public class CProductViewModel
    {
        public CProductViewModel()
        {
            _product = new TravelProduct();            
        }
        private TravelProduct _product;
        public List<CTravelDetailForEditViewModel> _CTravelDetailForEditViewModel;
        
        public TravelProduct product
        {
            get { return _product; }
            set { _product = value; }
        }

        public List<IFormFile> photo { get; set; } //圖片的檔案
        public List<string> TravelPicturePath //圖片的路徑
        {
            get;
            set;
        }
        [DisplayName("圖片描述")]
        public List<string> TravelPictureText //圖片描述
        {
            get;
            set;
        }
        public List<int> TravelPictureId //圖片ID
        {
            get;
            set;
        }
        public List<int> PictureCount //紀錄View的圖片位於第幾個欄位
        {
            get;
            set;
        }
        public List<IFormFile> CreateNewPhoto { get; set; } //在編輯時新增的圖片檔案
        public List<string> CreateNewTravelPicturePath //在編輯時新增的圖片路徑
        {
            get;
            set;
        }
        public List<string> CreateNewTravelPictureText //在編輯時新增的圖片描述
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
            get { return (int)_product.TravelProductTypeId; }
            set { _product.TravelProductTypeId = value; }
        }
        [DisplayName("最大人數")]

        public int Quantity
        {
            get { return _product.Quantity; }
            set { _product.Quantity = value; }
        }
        [DisplayName("剩餘數量")]
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
        [DisplayName("行程分類")]
        public string TravelProductTypeName { get; set; }
        [DisplayName("旅遊國家")]
        public string CountryName { get; set; }
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

    }

}
