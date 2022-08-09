using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace Theatre.DataProcessor.ImportDto
{
    [JsonObject]
    public class ImportTicketDto
    {
        [Range(1, 100)]
        [JsonProperty("Price")]
        public decimal Price { get; set; }

        [Range(1, 10)]
        [JsonProperty("RowNumber")]
        public sbyte RowNumber { get; set; }

        [JsonProperty("PlayId")]
        public int PlayId { get; set; }
    }
}