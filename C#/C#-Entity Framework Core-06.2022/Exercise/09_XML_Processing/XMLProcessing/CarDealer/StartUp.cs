using CarDealer.Data;
using CarDealer.DTO.Input;
using CarDealer.DTO.Output;
using CarDealer.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using static CarDealer.Data.XmlHelper;

namespace CarDealer
{
    public class StartUp
    {
        public static void Main()
        {
            var context = new CarDealerContext();

            ////2. Import Data
            //context.Database.EnsureDeleted();
            //context.Database.EnsureCreated();

            ////Query 9. Import Suppliers
            //var suppliersXml = File.ReadAllText("../../../Datasets/Input/suppliers.xml");
            //Console.WriteLine(ImportSuppliers(context, suppliersXml));

            ////Query 10. Import Parts
            //var partsXml = File.ReadAllText("../../../Datasets/Input/parts.xml");
            //Console.WriteLine(ImportParts(context, partsXml));

            ////Query 11. Import Cars
            //var carsXml = File.ReadAllText("../../../Datasets/Input/cars.xml");
            //Console.WriteLine(ImportCars(context, carsXml));

            ////Query 12. Import Customers
            //var customersXml = File.ReadAllText("../../../Datasets/Input/customers.xml");
            //Console.WriteLine(ImportCustomers(context, customersXml));

            ////Query 13. Import Sales
            //var salesXml = File.ReadAllText("../../../Datasets/Input/sales.xml");
            //Console.WriteLine(ImportSales(context, salesXml));

            ////3.Query and Export Data
            ////Query 14. Export Cars With Distance
            //Console.WriteLine(GetCarsWithDistance(context));

            ////Query 15. Export Cars from make BMW
            //Console.WriteLine(GetCarsFromMakeBmw(context));

            ////Query 16. GetLocalSuppliers
            //Console.WriteLine(GetLocalSuppliers(context));

            ////Query 17. Export Cars with Their List of Parts
            //Console.WriteLine(GetCarsWithTheirListOfParts(context));

            ////Query 18. Export Total Sales by Customer
            //Console.WriteLine(GetTotalSalesByCustomer(context));

            ////Query 19. Export Sales with Applied Discount
            //Console.WriteLine(GetSalesWithAppliedDiscount(context));
        }

        //Query 9. Import Suppliers
        public static string ImportSuppliers(CarDealerContext context, string inputXml)
        {
            var mapper = MapperHelper.InicializeMapper();

            var suppliersDto = XmlConverter.Deserializer<InputSupplierDto>(inputXml, "Suppliers");

            var suppliers = mapper.Map<IEnumerable<Supplier>>(suppliersDto);

            context.AddRange(suppliers);
            context.SaveChanges();

            return $"Successfully imported {suppliers.Count()}";
        }

        //Query 10. Import Parts
        public static string ImportParts(CarDealerContext context, string inputXml)
        {
            var mapper = MapperHelper.InicializeMapper();

            var suppliers = context.Suppliers.Select(s => s.Id).ToArray();

            var partsDto = XmlConverter.Deserializer<InputPartDto>(inputXml, "Parts");

            var parts = mapper.Map<IEnumerable<Part>>(partsDto.Where(p => suppliers.Contains(p.SupplierId)));

            context.AddRange(parts);
            context.SaveChanges();

            return $"Successfully imported {parts.Count()}";
        }

        //Query 11. Import Cars
        public static string ImportCars(CarDealerContext context, string inputXml)
        {
            var mapper = MapperHelper.InicializeMapper();

            var carsDto = XmlConverter.Deserializer<InputCarDto>(inputXml, "Cars");

            var cars = new List<Car>();

            foreach (var car in carsDto)
            {
                var currentcar = new Car
                {
                    Make = car.Make,
                    Model = car.Model,
                    TravelledDistance = car.TravelledDistance
                };

                foreach (var part in car.Parts.Select(p => p.PartId).Distinct())
                {
                    var currentPart = new PartCar
                    {
                        Car = currentcar,
                        PartId = part
                    };

                    currentcar.PartCars.Add(currentPart);
                }

                cars.Add(currentcar);
            }

            context.AddRange(cars);
            context.SaveChanges();

            return $"Successfully imported {cars.Count}";
        }

        //Query 12. Import Customers
        public static string ImportCustomers(CarDealerContext context, string inputXml)
        {
            var mapper = MapperHelper.InicializeMapper();

            var customersDto = XmlConverter.Deserializer<InputCustomerDto>(inputXml, "Customers");

            var customers = mapper.Map<IEnumerable<Customer>>(customersDto);

            context.AddRange(customers);
            context.SaveChanges();

            return $"Successfully imported {customers.Count()}";
        }

        //Query 13. Import Sales
        public static string ImportSales(CarDealerContext context, string inputXml)
        {
            var mapper = MapperHelper.InicializeMapper();

            var cars = context.Cars.Select(c => c.Id).ToArray();

            var salesDto = XmlConverter.Deserializer<InputSaleDto>(inputXml, "Sales");

            var sales = mapper.Map<IEnumerable<Sale>>(salesDto.Where(s => cars.Contains(s.CarId)));

            context.AddRange(sales);
            context.SaveChanges();

            return $"Successfully imported {sales.Count()}";
        }

        //Query 14. Export Cars With Distance
        public static string GetCarsWithDistance(CarDealerContext context)
        {
            var cars = context.Cars
                .Where(c => c.TravelledDistance > 2000000)
                .OrderBy(c => c.Make)
                .ThenBy(c => c.Model)
                .Take(10)
                .Select(c => new OutputCarDto
                {
                    Make = c.Make,
                    Model = c.Model,
                    TravelledDistance = c.TravelledDistance
                })
                .ToArray();

            var stringRepresentation = XmlConverter.Serialize(cars, "cars");

            File.WriteAllText("../../../Datasets/Output/cars.xml", stringRepresentation);

            return stringRepresentation;
        }

        //Query 15. Export Cars from make BMW
        public static string GetCarsFromMakeBmw(CarDealerContext context)
        {
            var cars = context.Cars
                .Where(c => c.Make == "BMW")
                .OrderBy(c => c.Model)
                .ThenByDescending(c => c.TravelledDistance)
                .Select(c => new OutputCarBMWDto
                {
                    Id = c.Id,
                    Model = c.Model,
                    TravelledDistance = c.TravelledDistance
                })
                .ToArray();

            var stringRepresentation = XmlConverter.Serialize(cars, "cars");

            File.WriteAllText("../../../Datasets/Output/bmw-cars.xml", stringRepresentation);

            return stringRepresentation;
        }

        //Query 16. Export Local Suppliers
        public static string GetLocalSuppliers(CarDealerContext context)
        {
            var suppliers = context.Suppliers
                .Where(s => !s.IsImporter)
                .Select(s => new OutputSupplierDto
                {
                    Id = s.Id,
                    Name = s.Name,
                    Count = s.Parts.Count
                })
                .ToArray();

            var stringRepresentation = XmlConverter.Serialize(suppliers, "suppliers");

            File.WriteAllText("../../../Datasets/Output/local-suppliers.xml", stringRepresentation);

            return stringRepresentation;
        }

        //Query 17. Export Cars with Their List of Parts
        public static string GetCarsWithTheirListOfParts(CarDealerContext context)
        {
            var cars = context.Cars
                .Select(c => new OutputCarWithPartDto
                {
                    Make = c.Make,
                    Model = c.Model,
                    TravelledDistance = c.TravelledDistance,
                    Parts = c.PartCars.Select(pc => new OutputPartDto
                    {
                        Name = pc.Part.Name,
                        Price = pc.Part.Price
                    })
                    .OrderByDescending(p => p.Price)
                    .ToArray()
                })
                .OrderByDescending(c => c.TravelledDistance)
                .ThenBy(c => c.Model)
                .Take(5)
                .ToArray();

            var stringRepresentation = XmlConverter.Serialize(cars, "cars");

            File.WriteAllText("../../../Datasets/Output/cars-and-parts.xml", stringRepresentation);

            return stringRepresentation;
        }

        //Query 18. Export Total Sales by Customer
        public static string GetTotalSalesByCustomer(CarDealerContext context)
        {
            var customers = context.Customers
                .Include(c => c.Sales)
                .ThenInclude(c => c.Car)
                .ThenInclude(c => c.PartCars)
                .ThenInclude(c => c.Part)
                .Where(c => c.Sales.Count > 0)
                .ToArray()
            .Select(c => new OutputCustomerDto
            {
                FullName = c.Name,
                BoughtCars = c.Sales.Count(),
                SpentMoney = c.Sales.Sum(bc => bc.Car.PartCars.Sum(pc => pc.Part.Price))
            })
            .OrderByDescending(c => c.SpentMoney)
            .ToArray();

            var stringRepresentation = XmlConverter.Serialize(customers, "customers");

            File.WriteAllText("../../../Datasets/Output/customers-total-sales.xml", stringRepresentation);

            return stringRepresentation;
        }

        //Query 19. Export Sales with Applied Discount
        public static string GetSalesWithAppliedDiscount(CarDealerContext context)
        {
            var sales = context.Sales
                .Select(s => new OutputSaleDto
                {
                    Car = new OutputCarsAttributeDto
                    {
                        Make = s.Car.Make,
                        Model = s.Car.Model,
                        TravelledDistance = s.Car.TravelledDistance
                    },
                    Discount = s.Discount.ToString("F2"),
                    CustomerName = s.Customer.Name,
                    Price = s.Car.PartCars.Sum(p=>p.Part.Price).ToString("F2"),
                    PriceWithDiscount = (s.Car.PartCars.Sum(p => p.Part.Price) * (1-(s.Discount*0.01m))).ToString("F2")
                })
                .ToArray();

            var stringRepresentation = XmlConverter.Serialize(sales, "sales");

            File.WriteAllText("../../../Datasets/Output/sales-discounts.xml", stringRepresentation);

            return stringRepresentation;
        }
    }
}
