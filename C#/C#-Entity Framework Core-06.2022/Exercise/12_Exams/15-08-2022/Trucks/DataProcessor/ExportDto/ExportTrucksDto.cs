using Newtonsoft.Json;

namespace Trucks.DataProcessor.ExportDto
{
    [JsonObject]
    public class ExportTrucksDto
    {
        [JsonProperty("TruckRegistrationNumber")]
        public string TruckRegistrationNumber { get; set; }

        [JsonProperty("VinNumber")]
        public string VinNumber { get; set; }

        [JsonProperty("TankCapacity")]
        public int TankCapacity { get; set; }

        [JsonProperty("CargoCapacity")]
        public int CargoCapacity { get; set; }

        [JsonProperty("CategoryType")]
        public string CategoryType { get; set; }

        [JsonProperty("MakeType")]
        public string MakeType { get; set; }
    }
}