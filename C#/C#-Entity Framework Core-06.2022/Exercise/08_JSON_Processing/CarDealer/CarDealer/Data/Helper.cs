using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;

namespace CarDealer.Data
{
    internal class Helper
    {
        public static void MapperInitialiser()
        {
            Mapper.Initialize(cfg =>
            {
                cfg.AddProfile<CarDealerProfile>();
            });
        }

    }
}
