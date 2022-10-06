using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using System.Xml.Serialization;

namespace Trucks.DataProcessor.ImportDto
{
    [XmlType("Despatcher")]
    public class ImportDespatcherDto
    {
        [XmlElement("Name")]
        [StringLength(40,MinimumLength =2)]
        [Required]
        public string Name { get; set; }

        [XmlElement("Position")]
        [Required]
        public string Position { get; set; }

        [XmlArray("Trucks")]
        public ImportTruckDto[] Trucks { get; set; }
    }
}
