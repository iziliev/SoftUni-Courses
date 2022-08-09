using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace ProductShop.DTO.Output
{
    [XmlType("Users")]
    public class OutputCountUserDto
    {
        [XmlElement("count")]
        public int Count { get; set; }

        [XmlArray("users")]
        public OutputUserDto[] User { get; set; }
    }
}
