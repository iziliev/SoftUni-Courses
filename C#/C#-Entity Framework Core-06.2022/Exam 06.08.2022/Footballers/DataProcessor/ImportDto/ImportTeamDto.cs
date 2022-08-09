using Footballers.Data.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Footballers.DataProcessor.ImportDto
{
    [JsonObject]
    public class ImportTeamDto
    {
        [Required]
        [StringLength(40,MinimumLength =3)]
        [RegularExpression(@"^[A-Za-z0-9\s.-]+?$")]
        [JsonProperty(nameof(Name))]
        public string Name { get; set; }

        [Required]
        [StringLength(40,MinimumLength =2)]
        [JsonProperty(nameof(Nationality))]
        public string Nationality { get; set; }

        [JsonProperty(nameof(Trophies))]
        public string Trophies { get; set; }

        [JsonProperty(nameof(Footballers))]
        public HashSet<int> Footballers { get; set; }
    }
}
