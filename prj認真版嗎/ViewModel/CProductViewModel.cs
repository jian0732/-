using Microsoft.AspNetCore.Http;
using prj認真版嗎.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace prjMvcCoreModel.ViewModel
{
    public class CProductViewModel
    {
        public CProductViewModel()
        {
            _product = new TravelProduct();
            _productpic = new TravelPicture();
        }
        private TravelProduct _product;
        private TravelPicture _productpic;
        public TravelProduct product
        {
            get { return _product; }
            set { _product = value; }
        }
        public TravelPicture productpic
        {
            get { return _productpic; }
            set { _productpic = value; }
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
        //public string FimagePath
        //{
        //    get { return _product.FimagePath; }
        //    set { _product.FimagePath = value; }
        //}
        public IFormFile photo { get; set; }
    }
}
