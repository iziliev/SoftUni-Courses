using AutoMapper;
using CarDealer.Dto.Car;
using CarDealer.Dto.Customer;
using CarDealer.Dto.Parts;
using CarDealer.Dto.Sale;
using CarDealer.Dto.Suppliers;
using CarDealer.Models;
using System.Globalization;
using System.Linq;

namespace CarDealer
{
    public class CarDealerProfile:Profile
    {
        public CarDealerProfile()
        {
            this.CreateMap<ImportSuppliersDto, Supplier>();
            this.CreateMap<ImportPartDto, Part>();
            this.CreateMap<ImportCarDto, Car>();
            this.CreateMap<ImportCustomerDto, Customer>();
            this.CreateMap<ImportSaleDto, Sale>();

            this.CreateMap<Customer, ExportCustomerDto>()
                .ForMember(d=>d.BirthDate,mo=>mo.MapFrom(s=>s.BirthDate.ToString("dd/MM/yyyy",CultureInfo.InvariantCulture)));

            this.CreateMap<Supplier, ExportSupplierDto>()
                .ForMember(d=>d.PartsCount,mo=>mo.MapFrom(s=>s.Parts.Count));

            this.CreateMap<Customer, ExportCustomerSaleDto>()
               .ForMember(d => d.BoughtCars, mo => mo.MapFrom(s => s.Sales.Count))
               .ForMember(d => d.SpendMoney, mo => mo.MapFrom(s => s.Sales.Sum(x => x.Car.PartCars.Sum(x => x.Part.Price))));
        }
    }
}
