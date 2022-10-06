using System.ComponentModel.DataAnnotations;
using System.Xml.Serialization;
using Trucks.Data.Models.Enums;

namespace Trucks.DataProcessor.ImportDto
{
    [XmlType("Truck")]
    public class ImportTruckDto
    {
        [XmlElement("RegistrationNumber")]
        [StringLength(8)]
        [RegularExpression(@"([A-Z]){2}([0-9]){4}([A-Z]){2}")]
        [Required]
        public string RegistrationNumber { get; set; }

        [XmlElement("VinNumber")]
        [StringLength(17)]
        [Required]
        public string VinNumber { get; set; }

        [XmlElement("TankCapacity")]
        [Range(950,1420)]
        public int TankCapacity { get; set; }

        [Range(5000, 29000)]
        [XmlElement(nameof(CargoCapacity))]
        public int CargoCapacity { get; set; }

        [XmlElement("CategoryType")]
        [Required]
        public string CategoryType { get; set; }

        [XmlElement("MakeType")]
        [Required]
        public string MakeType { get; set; }
    }
}