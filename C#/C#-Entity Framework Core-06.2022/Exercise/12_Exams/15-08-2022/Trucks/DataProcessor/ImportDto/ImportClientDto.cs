using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Trucks.DataProcessor.ImportDto
{
    [JsonObject]
    public class ImportClientDto
    {
        [JsonProperty]
        [Required]
        [StringLength(40,MinimumLength =3)]
        public string Name { get; set; }

        [JsonProperty]
        [Required]
        [StringLength(40, MinimumLength = 2)]
        public string Nationality { get; set; }

        [JsonProperty]
        [Required]
        public string Type { get; set; }

        [JsonProperty]
        public int[] Trucks { get; set; }
    }
}
