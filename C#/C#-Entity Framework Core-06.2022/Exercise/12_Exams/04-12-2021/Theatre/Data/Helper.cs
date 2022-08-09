using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Xml.Serialization;
using Theatre.DataProcessor.ImportDto;

namespace Theatre.Data
{
    public class Helper
    {
        public static T XmlDeserialise<T> (string xmlString, string roots)
        {
            var root = new XmlRootAttribute(roots);
            var serialiser = new XmlSerializer(typeof(T), root);
            var reader = new StringReader(xmlString);
            var dto = (T)serialiser.Deserialize(reader);

            return dto;
        }

        public static string XmlSerialise<T>(T dto, string roots)
        {
            var sb = new StringBuilder();
            var root = new XmlRootAttribute(roots);
            var namespaces = new XmlSerializerNamespaces();
            namespaces.Add(string.Empty, string.Empty);
            var serialiser = new XmlSerializer(typeof(T), root);
            var writer = new StringWriter(sb);
            serialiser.Serialize(writer, dto,namespaces);

            return sb.ToString().Trim();
        }
    }
}
