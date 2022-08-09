using AutoMapper;

namespace CarDealer.Data
{
    public class MapperHelper
    {
        public static IMapper InicializeMapper()
        {
            var config = new MapperConfiguration(cnf =>
            {
                cnf.AddProfile<CarDealerProfile>();
            });

            IMapper mapper = new Mapper(config);

            return mapper;
        }
    }
}
