using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace CarDealer.DTO.Input
{
    [XmlType("partId")]
    public class InputPartCarDto
    {
        [XmlAttribute("id")]
        public int PartId { get; set; }
    }
}
