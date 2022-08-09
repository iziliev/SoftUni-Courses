using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace CarDealer.Dto.Suppliers
{
    [JsonObject]
    public class ExportSupplierDto
    {
        [JsonProperty("Id")]
        public int Id { get; set; }

        [JsonProperty("Name")]
        public string Name { get; set; }

        [JsonProperty("PartsCount")]
        public int PartsCount { get; set; }
    }
}
