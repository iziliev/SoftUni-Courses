using CarDealer.Dto.Parts;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace CarDealer.Dto.Car
{
    [JsonObject]
    public class ExportCarWithPartDto
    {
        [JsonProperty("car")]
        public ExportCarInfoDto Car { get; set; }

        [JsonProperty("parts")]
        public ExportPartDto[] Parts { get; set; }
    }
}
