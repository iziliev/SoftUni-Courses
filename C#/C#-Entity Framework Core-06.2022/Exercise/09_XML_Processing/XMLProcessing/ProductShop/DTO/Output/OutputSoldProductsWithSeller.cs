using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace ProductShop.DTO.Output
{
    [XmlType("User")]
    public class OutputSoldProductsWithSeller
    {
        [XmlElement("firstName")]
        public string FirstName { get; set; }
        
        [XmlElement("lastName")]
        public string LastName { get; set; }

        [XmlArray("soldProducts")]
        public OutputProductDto[] SoldProducts { get; set; }
    }
}
