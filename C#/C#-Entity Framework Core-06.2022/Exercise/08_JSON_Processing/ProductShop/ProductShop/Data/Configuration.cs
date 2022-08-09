using AutoMapper;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProductShop.Data
{
    public class Configuration
    {
        public static string connection = @"Server=.;Database=ProductShop;User Id=sa;Password=Ilievi84;Encrypt=false;";

        public static IMapper InicializeMapper()
        {
            var config = new MapperConfiguration(cnf =>
            {
                cnf.AddProfile<ProductShopProfile>();
            });

            IMapper mapper = new Mapper(config);

            return mapper;
        }

        public static JsonSerializerSettings JsonFormatingForPrint()
        {
            return new JsonSerializerSettings
            {
                ContractResolver = new DefaultContractResolver
                {
                    NamingStrategy = new CamelCaseNamingStrategy()
                    {
                        OverrideSpecifiedNames = false,
                        
                    }
                },
                Formatting = Formatting.Indented,
                NullValueHandling = NullValueHandling.Ignore
            };
        }
    }
}
