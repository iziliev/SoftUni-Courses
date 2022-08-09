﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace CarDealer.Dto.Car
{
    internal class ExportCarSalesDto
    {
        [JsonProperty("car")]
        public ExportCarInfoDto Car { get; set; }

        [JsonProperty("customerName")]
        public string CustomerName { get; set; }

        [JsonProperty("Discount")]
        public string Discount { get; set; }

        [JsonProperty("price")]
        public string Price { get; set; }

        [JsonProperty("priceWithDiscount")]
        public string PriceWithDiscount => (decimal.Parse(this.Price) - (decimal.Parse(this.Price) * (decimal.Parse(this.Discount) / 100))).ToString("F2");
    }
}
