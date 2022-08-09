using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace ProductShop.DTO.Input
{
    [XmlType("Category")]
    public class InputCategoryDto
    {
        [XmlElement("name")]
        public string Name { get; set; }
    }
}
