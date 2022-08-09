using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Footballers.DataProcessor.ExportDto
{
    [JsonObject]
    public class ExportTeamDto
    {
        [JsonProperty(nameof(Name))]
        public string Name { get; set; }

        [JsonProperty(nameof(Footballers))]
        public ExportFootballerDto[] Footballers { get; set; }
    }
}
