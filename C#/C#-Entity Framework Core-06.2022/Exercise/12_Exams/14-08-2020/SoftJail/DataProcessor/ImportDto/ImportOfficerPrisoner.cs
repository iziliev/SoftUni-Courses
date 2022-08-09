using System.Xml.Serialization;

namespace SoftJail.DataProcessor.ImportDto
{
    [XmlType("Prisoner")]
    public class ImportOfficerPrisoner
    {
        [XmlAttribute("id")]
        public int Id { get; set; }
    }
}