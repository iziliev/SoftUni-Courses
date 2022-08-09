using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;

namespace ProductShop.Data
{
    public class MapperHelper
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
    }
}
