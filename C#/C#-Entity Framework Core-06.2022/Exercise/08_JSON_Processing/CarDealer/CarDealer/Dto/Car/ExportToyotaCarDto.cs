﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace CarDealer.Dto.Car
{
    public class ExportToyotaCarDto
    {
        [JsonProperty("Id")]
        public int Id { get; set; }

        [JsonProperty("Make")]
        public string Make { get; set; }

        [JsonProperty("Model")]
        public string Model { get; set; }

        [JsonProperty("TravelledDistance")]
        public long TravelledDistance { get; set; }
    }
}
