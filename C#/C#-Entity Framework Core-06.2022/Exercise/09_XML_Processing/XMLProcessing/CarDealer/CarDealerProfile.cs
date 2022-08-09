using AutoMapper;
using CarDealer.DTO.Input;
using CarDealer.Model;

namespace CarDealer
{
    public class CarDealerProfile:Profile
    {
        public CarDealerProfile()
        {
            this.CreateMap<InputSupplierDto,Supplier>();
            this.CreateMap<InputPartDto, Part>();
            this.CreateMap<InputCarDto, Car>();
            this.CreateMap<InputCustomerDto, Customer>();
            this.CreateMap<InputSaleDto, Sale>();
        }
    }
}
