using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Trucks.DataProcessor.ExportDto
{
    [JsonObject]
    public class ExportClientsWithTruckDto
    {
        [JsonProperty("Name")]
        public string Name { get; set; }

        [JsonProperty("Trucks")]
        public ExportTrucksDto[] Trucks { get; set; }
    }
}
