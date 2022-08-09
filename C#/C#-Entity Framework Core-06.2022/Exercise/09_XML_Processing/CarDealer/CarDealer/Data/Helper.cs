using AutoMapper;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Xml.Serialization;

namespace CarDealer.Data
{
    public class Helper
    {
        public static T XmlDeserialise<T>(string inputXml,string rootName)
        {
            var root = new XmlRootAttribute(rootName);
            var serilisation = new XmlSerializer(typeof(T), root);
            using var reader = new StringReader(inputXml);
            var dto = (T)serilisation.Deserialize(reader);

            return dto;
        }

        public static string XmlSerialise<T>(T dto, string rootName)
        {
            var sb = new StringBuilder();
            var root = new XmlRootAttribute(rootName);
            var serilisation = new XmlSerializer(typeof(T), root);
            using var writer = new StringWriter(sb);
            var namespaces = new XmlSerializerNamespaces();
            namespaces.Add(string.Empty, string.Empty);
            serilisation.Serialize(writer,dto,namespaces);
            return sb.ToString().Trim();
        }
    }
}
