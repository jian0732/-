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
        }
        private TravelProduct _product;
        public TravelProduct product
        {
            get { return _product; }
            set { _product = value; }
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
        [DisplayName("成本")]
        public int Cost
        {
            get { return _product.Cost; }
            set { _product.Cost = value; }
        }

        //public string FimagePath
        //{
        //    get { return _product.FimagePath; }
        //    set { _product.FimagePath = value; }
        //}
        public IFormFile photo { get; set; }
    }
}
