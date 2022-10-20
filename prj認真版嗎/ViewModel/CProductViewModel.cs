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
            _TravelProductDetail = new TravelProductDetail();
        }
        private TravelProduct _product;
        private TravelProductDetail _TravelProductDetail;

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
        [DisplayName("品名")]
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

        //ProductDetail屬性欄位

        public int TravelProductDetailID
        {
            get { return _TravelProductDetail.TravelProductDetailId; }
            set { _TravelProductDetail.TravelProductDetailId = value; }
        }
    }

}
