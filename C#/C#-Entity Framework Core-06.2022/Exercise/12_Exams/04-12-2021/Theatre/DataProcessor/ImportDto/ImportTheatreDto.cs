using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Theatre.DataProcessor.ImportDto
{
    [JsonObject]
    public class ImportTheatreDto
    {
        [Required]
        [StringLength(30, MinimumLength = 4)]
        [JsonProperty("Name")]
        public string Name { get; set; }

        [Range(1, 10)]
        [JsonProperty("NumberOfHalls")]
        public sbyte NumberOfHalls { get; set; }

        [Required]
        [StringLength(30, MinimumLength = 4)]
        [JsonProperty("Director")]
        public string Director { get; set; }

        [JsonProperty("Tickets")]
        public ImportTicketDto[] Tickets { get; set; }
    }
}
