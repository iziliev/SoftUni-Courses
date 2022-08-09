using AutoMapper;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Text;
using System.Xml.Serialization;
using ValidationContext = System.ComponentModel.DataAnnotations.ValidationContext;

namespace ProductShop.Data
{
    public class Helper
    {
        public static IMapper InicializeMapper()
        {
            var config = new MapperConfiguration(cnf =>
            {
                cnf.AddProfile<ProductShopProfile>();
            });

            IMapper mapper = new Mapper(config);

            return mapper;
        }

        public static T XmlDeserialise<T>(string inputXml, string rootName)
        {
            var rootAttribute = new XmlRootAttribute(rootName);
            var serialisation = new XmlSerializer(typeof(T), rootAttribute);
            using var reader = new StringReader(inputXml);
            var dto = (T)serialisation.Deserialize(reader);
            return dto;
        }

        public static string XmlSerialise<T>(T dto, string rootName)
        {
            var sb = new StringBuilder();
            var rootAttribute = new XmlRootAttribute(rootName);
            var namespaces = new XmlSerializerNamespaces();
            namespaces.Add(string.Empty, string.Empty);
            var serialisation = new XmlSerializer(typeof(T), rootAttribute);
            using var writer = new StringWriter(sb);
            serialisation.Serialize(writer, dto, namespaces);

            return sb.ToString().Trim();
        }

        public static bool IsValid(object dto)
        {
            var validationContext = new ValidationContext(dto);
            var validationResult = new List<ValidationResult>();

            return Validator.TryValidateObject(dto, validationContext, validationResult, true);
        }

        public static MapperConfiguration ExportDtoMapperInicialize()
        {
            MapperConfiguration config = new MapperConfiguration(cnf =>
            {
                cnf.AddProfile<ProductShopProfile>();
            });

            return config;
        }
    }
}
