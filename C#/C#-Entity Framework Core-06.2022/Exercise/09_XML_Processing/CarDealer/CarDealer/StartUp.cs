using AutoMapper;
using AutoMapper.QueryableExtensions;
using CarDealer.Data;
using CarDealer.Dtos.Export;
using CarDealer.Dtos.Import;
using CarDealer.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml.Serialization;

namespace CarDealer
{
    public class StartUp
    {
        public static string path = "../../../Datasets/";

        public static void Main()
        {
            var context = new CarDealerContext();

            //context.Database.EnsureDeleted();
            //context.Database.EnsureCreated();

            //var suppliersXml = File.ReadAllText($"{path}suppliers.xml");
            //Console.WriteLine(ImportSuppliers(context, suppliersXml));

            //var partsXml = File.ReadAllText($"{path}parts.xml");
            //Console.WriteLine(ImportParts(context, partsXml));

            //var carsXml = File.ReadAllText($"{path}cars.xml");
            //Console.WriteLine(ImportCars(context, carsXml));

            //var customersXml = File.ReadAllText($"{path}customers.xml");
            //Console.WriteLine(ImportCustomers(context, customersXml));

            //var salesXml = File.ReadAllText($"{path}sales.xml");
            //Console.WriteLine(ImportSales(context, salesXml));

            //var resultCarByDistance = GetCarsWithDistance(context);
            //File.WriteAllText($"{path}carsDistance.xml",resultCarByDistance);
            //Console.WriteLine(resultCarByDistance);

            //var resultBmwCars = GetCarsFromMakeBmw(context);
            //File.WriteAllText($"{path}bmw-cars.xml.xml", resultBmwCars);
            //Console.WriteLine(resultBmwCars);

            //var resultLocalSupplier = GetLocalSuppliers(context);
            //File.WriteAllText($"{path}local-suppliers.xml", resultLocalSupplier);
            //Console.WriteLine(resultLocalSupplier);

            //var resultCarWithParts = GetCarsWithTheirListOfParts(context);
            //File.WriteAllText($"{path}cars-and-parts.xml", resultCarWithParts);
            //Console.WriteLine(resultCarWithParts);

            //var resultCustomers = GetTotalSalesByCustomer(context);
            //File.WriteAllText($"{path}customers-total-sales.xml", resultCustomers);
            //Console.WriteLine(resultCustomers);

            var resultSales = GetSalesWithAppliedDiscount(context);
            File.WriteAllText($"{path}sales-discounts.xml", resultSales);
            Console.WriteLine(resultSales);
        }

        public static string ImportSuppliers(CarDealerContext context, string inputXml)
        {
            var suppliersDto = Helper.XmlDeserialise<ImportSuppliersDto[]>(inputXml, "Suppliers");

            var suppliers = new List<Supplier>();

            foreach (var supplierDto in suppliersDto)
            {
                suppliers.Add(new Supplier
                {
                    Name = supplierDto.Name,
                    IsImporter = supplierDto.IsImporter
                });
            }

            context.AddRange(suppliers);
            context.SaveChanges();

            return $"Successfully imported {suppliers.Count}";
        }

        public static string ImportParts(CarDealerContext context, string inputXml)
        {
            var partsDto = Helper.XmlDeserialise<ImportPartsDto[]>(inputXml, "Parts");

            var parts = new List<Part>();

            foreach (var partDto in partsDto)
            {
                if (!context.Suppliers.Any(s => s.Id == partDto.SupplierId))
                {
                    continue;
                }

                parts.Add(new Part
                {
                    Name = partDto.Name,
                    Price = partDto.Price,
                    Quantity = partDto.Quantity,
                    SupplierId = partDto.SupplierId
                });
            }
            context.AddRange(parts);
            context.SaveChanges();

            return $"Successfully imported {parts.Count}";
        }

        public static string ImportCars(CarDealerContext context, string inputXml)
        {
            var carsDto = Helper.XmlDeserialise<ImportCarsDto[]>(inputXml, "Cars");

            var cars = new List<Car>();

            foreach (var carDto in carsDto)
            {
                var parts = new List<PartCar>();

                foreach (var partDto in carDto.Parts)
                {
                    if (!context.Parts.Any(p => p.Id == partDto.Id) || parts.Any(p => p.PartId == partDto.Id))
                    {
                        continue;
                    }

                    parts.Add(new PartCar
                    {
                        PartId = partDto.Id
                    });
                }

                cars.Add(new Car
                {
                    Make = carDto.Make,
                    Model = carDto.Model,
                    TravelledDistance = carDto.TravelledDistance,
                    PartCars = parts
                });
            }

            context.AddRange(cars);
            context.SaveChanges();

            return $"Successfully imported {cars.Count}";
        }

        public static string ImportCustomers(CarDealerContext context, string inputXml)
        {
            var customersDto = Helper.XmlDeserialise<ImportCustomersDto[]>(inputXml, "Customers");

            var customers = new List<Customer>();

            foreach (var customerDto in customersDto)
            {
                customers.Add(new Customer
                {
                    Name = customerDto.Name,
                    BirthDate = customerDto.BirthDate,
                    IsYoungDriver = customerDto.IsYoungDriver
                });
            }

            context.AddRange(customers);
            context.SaveChanges();

            return $"Successfully imported {customers.Count}";
        }

        public static string ImportSales(CarDealerContext context, string inputXml)
        {
            var salesDto = Helper.XmlDeserialise<ImportSalesDto[]>(inputXml, "Sales");

            var sales = new List<Sale>();

            foreach (var saleDto in salesDto)
            {
                if (!context.Cars.Any(c => c.Id == saleDto.CarId))
                {
                    continue;
                }

                sales.Add(new Sale
                {
                    CarId = saleDto.CarId,
                    CustomerId = saleDto.CustomerId,
                    Discount = saleDto.Discount
                });
            }

            context.AddRange(sales);
            context.SaveChanges();

            return $"Successfully imported {sales.Count}";
        }

        public static string GetCarsWithDistance(CarDealerContext context)
        {
            var carsDto = context.Cars
                .Where(c => c.TravelledDistance > 2000000)
                .OrderBy(c => c.Make)
                .ThenBy(c => c.Model)
                .Take(10)
                .Select(c => new ExportCarByDistanceDto
                {
                    Make = c.Make,
                    Model = c.Model,
                    TravelledDistance = c.TravelledDistance
                })
                .ToArray();

            return Helper.XmlSerialise(carsDto, "cars");
        }

        public static string GetCarsFromMakeBmw(CarDealerContext context)
        {
            var cars = context.Cars
                .Where(c => c.Make == "BMW")
                .OrderBy(c => c.Model)
                .ThenByDescending(c => c.TravelledDistance)
                .Select(c => new ExportBmwCarsDto
                {
                    Id = c.Id,
                    Model = c.Model,
                    TravelledDistance = c.TravelledDistance
                })
                .ToArray();

            return Helper.XmlSerialise(cars, "cars");
        }

        public static string GetLocalSuppliers(CarDealerContext context)
        {
            var suppliers = context.Suppliers
                .Where(s => !s.IsImporter)
                .Select(s => new ExportLocalSuppliersDto
                {
                    Id = s.Id,
                    Name = s.Name,
                    PartsCount = s.Parts.Count
                })
                .ToArray();

            return Helper.XmlSerialise(suppliers, "suppliers");
        }

        public static string GetCarsWithTheirListOfParts(CarDealerContext context)
        {
            var cars = context.Cars
                .Select(c => new ExportCarsWithPartsDto
                {
                    Make = c.Make,
                    Model = c.Model,
                    TravelledDistance = c.TravelledDistance,
                    Parts = c.PartCars.Select(p => new ExportPartsInfoDto
                    {
                        Name = p.Part.Name,
                        Price = p.Part.Price
                    })
                    .OrderByDescending(p => p.Price)
                    .ToArray()
                })
                .OrderByDescending(c => c.TravelledDistance)
                .ThenBy(c=>c.Model)
                .Take(5)
                .ToArray();

            return Helper.XmlSerialise(cars, "cars");
        }

        public static string GetTotalSalesByCustomer(CarDealerContext context)
        {
            var customers = context.Sales
                .Where(c=>c.Customer.Sales.Count>=1)
                .Select(c => new ExportTotalSalesbyCustomerDto
                {
                    FullName = c.Customer.Name,
                    BoughtCars = c.Customer.Sales.Count,
                    SpentMoney = c.Car.PartCars.Sum(y => y.Part.Price)
                })
                .OrderByDescending(c => c.SpentMoney)
                .ToArray();

            return Helper.XmlSerialise(customers, "customers");
        }

        public static string GetSalesWithAppliedDiscount(CarDealerContext context)
        {
            var sales = context.Sales
                .Select(s => new ExportSalesDto
                {
                    Car = new ExportCarInfoAttribute
                    {
                        Make = s.Car.Make,
                        Model = s.Car.Model,
                        TravelledDistance = s.Car.TravelledDistance
                    },
                    Discount = s.Discount,
                    CustomerName = s.Customer.Name,
                    Price = s.Car.PartCars.Sum(x => x.Part.Price),
                    PriceWithDiscount = s.Car.PartCars.Sum(x => x.Part.Price) * (1-s.Discount/100)
                })
                .ToArray();

            return Helper.XmlSerialise(sales, "sales");
        }
    }
}