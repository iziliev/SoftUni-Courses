using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace NoSQLCRUDOperations.Models
{
    [JsonObject]
    public class ImportArticleDto
    {
        [Required]
        [JsonProperty("author")]
        public string Author { get; set; }

        [Required]
        [JsonProperty("date")]
        public string Date { get; set; }

        [Required]
        [JsonProperty("name")]
        public string Name { get; set; }

        [Required]
        [JsonProperty("rating")]
        public string Rating { get; set; }
    }
}
