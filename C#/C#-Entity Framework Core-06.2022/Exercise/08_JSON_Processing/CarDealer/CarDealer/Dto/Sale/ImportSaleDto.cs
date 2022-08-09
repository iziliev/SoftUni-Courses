using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace CarDealer.Dto.Sale
{
    [JsonObject]
    public class ImportSaleDto
    {
        [JsonProperty("discount")]
        public decimal Discount { get; set; }

        [JsonProperty("carId")]
        public int CarId { get; set; }

        [JsonProperty("customerId")]
        public int CustomerId { get; set; }       
    }
}
