﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace CarDealer.DTO.Output
{
    [XmlType("suplier")]
    public class OutputSupplierDto
    {
        [XmlAttribute("id")]
        public int Id { get; set; }

        [XmlAttribute("name")]
        public string Name { get; set; }

        [XmlAttribute("parts-count")]
        public int Count { get; set; }
    }
}
