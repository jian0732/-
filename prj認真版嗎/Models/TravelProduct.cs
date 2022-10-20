﻿using System;
using System.Collections.Generic;

#nullable disable

namespace prj認真版嗎.Models
{
    public partial class TravelProduct
    {
        public TravelProduct()
        {
            OrderDetails = new HashSet<OrderDetail>();
            ProductToTransportations = new HashSet<ProductToTransportation>();
            TravelPictures = new HashSet<TravelPicture>();
        }

        public int TravelProductId { get; set; }
        public string TravelProductName { get; set; }
        public decimal Price { get; set; }
        public int TravelProductTypeId { get; set; }
        public int Stocks { get; set; }
        public string Description { get; set; }
        public int CountryId { get; set; }
        public int Cost { get; set; }
        public string EventIntroduction { get; set; }
        public string PreparationDescription { get; set; }
        public string MapUrl { get; set; }
        public string ProductStatus { get; set; }

        public virtual Country Country { get; set; }
        public virtual TravelProductType TravelProductType { get; set; }
        public virtual ICollection<OrderDetail> OrderDetails { get; set; }
        public virtual ICollection<ProductToTransportation> ProductToTransportations { get; set; }
        public virtual ICollection<TravelPicture> TravelPictures { get; set; }
    }
}
