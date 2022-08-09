using System.Xml.Serialization;

namespace ProductShop.DTO.Output
{
    [XmlType("User")]
    public class OutputUserDto
    {
        [XmlElement("firstName")]
        public string FirstName { get; set; }

        [XmlElement("lastName")]
        public string LastName { get; set; }

        [XmlElement("age")]
        public int? Age { get; set; }

        [XmlElement("SoldProducts")]
        public OutputProductCountDto SoldProducts { get; set; }
    }
}