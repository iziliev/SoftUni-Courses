using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace NoSQLCRUDOperations.Models
{
    [JsonObject]
    public class ImportArticlesDto
    {
        internal object toList;

        [JsonProperty("articles")]
        public ImportArticleDto[] Articles { get; set; }
    }
}
