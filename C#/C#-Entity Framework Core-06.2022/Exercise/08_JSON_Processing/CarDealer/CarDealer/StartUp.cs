using AutoMapper;
using AutoMapper.QueryableExtensions;
using CarDealer.Data;
using CarDealer.Dto.Car;
using CarDealer.Dto.Customer;
using CarDealer.Dto.Parts;
using CarDealer.Dto.Sale;
using CarDealer.Dto.Suppliers;
using CarDealer.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace CarDealer
{
    public class StartUp
    {
        public static string pathFolder = "../../../Datasets/";
        
        public static void Main(string[] args)
        {
            var context = new CarDealerContext();

            //context.Database.EnsureDeleted();
            //context.Database.EnsureCreated();

            Helper.MapperInitialiser();

            //var supplierJson = File.ReadAllText($"{pathFolder}suppliers.json");
            //Console.WriteLine(ImportSuppliers(context, supplierJson));

            //var partJson = File.ReadAllText($"{pathFolder}parts.json");
            //Console.WriteLine(ImportParts(context, partJson));

            //var carJson = File.ReadAllText($"{pathFolder}cars.json");
            //Console.WriteLine(ImportCars(context, carJson));

            //var customerJson = File.ReadAllText($"{pathFolder}customers.json");
            //Console.WriteLine(ImportCustomers(context, customerJson));

            //var saleJson = File.ReadAllText($"{pathFolder}sales.json");
            //Console.WriteLine(ImportSales(context, saleJson));

            //var customers = GetOrderedCustomers(context);
            //File.WriteAllText($"{pathFolder}ordered-customers.json",customers);
            //Console.WriteLine(customers);

            //var toyotaCars = GetCarsFromMakeToyota(context);
            //File.WriteAllText($"{pathFolder}toyota-cars.json",toyotaCars);
            //Console.WriteLine(toyotaCars);

            //var localSuppliers = GetLocalSuppliers(context);
            //File.WriteAllText($"{pathFolder}local-suppliers.json", localSuppliers);
            //Console.WriteLine(localSuppliers);

            //var carWithParts = GetCarsWithTheirListOfParts(context);
            //File.WriteAllText($"{pathFolder}cars-and-parts.json", carWithParts);
            //Console.WriteLine(carWithParts);

            var totalSales = GetTotalSalesByCustomer(context);
            File.WriteAllText($"{pathFolder}customers-total-sales.json", totalSales);
            Console.WriteLine(totalSales);

            //var salesWithDiscount = GetSalesWithAppliedDiscount(context);
            //File.WriteAllText($"{pathFolder}sales-discounts.json", salesWithDiscount);
            //Console.WriteLine(salesWithDiscount);
        }

        public static string ImportSuppliers(CarDealerContext context, string inputJson)
        {
            var suppliersDto = JsonConvert.DeserializeObject<ImportSuppliersDto[]>(inputJson);

            var suppliers = new List<Supplier>();

            foreach (var supplierDto in suppliersDto)
            {
                var supplier = Mapper.Map<Supplier>(supplierDto);
                suppliers.Add(supplier);
            }

            context.AddRange(suppliers);
            context.SaveChanges();

            return $"Successfully imported {suppliers.Count}.";
        }

        public static string ImportParts(CarDealerContext context, string inputJson)
        {
           
            var partsDto = JsonConvert.DeserializeObject<ImportPartDto[]>(inputJson);

            var parts = new List<Part>();

            foreach (var partDto in partsDto)
            {
                if (!context.Suppliers.Any(s=>s.Id == partDto.SupplierId))
                {
                    continue;
                }

                var part = Mapper.Map<Part>(partDto);
                parts.Add(part);
            }

            context.AddRange(parts);
            context.SaveChanges();

            return $"Successfully imported {parts.Count}.";
        }

        public static string ImportCars(CarDealerContext context, string inputJson)
        {
            var carsDto = JsonConvert.DeserializeObject<ImportCarDto[]>(inputJson);

            var cars = new List<Car>();

            foreach (var carDto in carsDto)
            {
                var parts = new List<PartCar>();

                foreach (var partId in carDto.PartsId.Distinct())
                {
                    var part = context.Parts.FirstOrDefault(p => p.Id == partId);

                    if (part == null)
                    {
                        continue;
                    }

                    parts.Add(new PartCar
                    {
                        PartId = partId
                    });
                }

                var car = Mapper.Map<Car>(carDto);
                car.PartCars = parts;
                cars.Add(car);
            }

            context.AddRange(cars);
            context.SaveChanges();

            return $"Successfully imported {cars.Count}.";
        }

        public static string ImportCustomers(CarDealerContext context, string inputJson)
        {
            var customersDto = JsonConvert.DeserializeObject<ImportCustomerDto[]>(inputJson);

            var customers = new List<Customer>();

            foreach (var customerDto in customersDto)
            {
                var customer = Mapper.Map<Customer>(customerDto);

                customers.Add(customer);
            }

            context.AddRange(customers);
            context.SaveChanges();

            return $"Successfully imported {customers.Count}.";
        }

        public static string ImportSales(CarDealerContext context, string inputJson)
        {
            var salesDto = JsonConvert.DeserializeObject<ImportSaleDto[]>(inputJson);

            var sales = new List<Sale>();

            foreach (var saleDto in salesDto)
            {
                //var car = context.Cars.FirstOrDefault(c => c.Id == saleDto.CarId);
                //var customer = context.Customers.FirstOrDefault(c => c.Id == saleDto.CustomerId);

                //if (car == null || customer == null)
                //{
                //    continue;
                //}

                var sale = Mapper.Map<Sale>(saleDto);

                //if (sales.Contains(sale))
                //{
                //    continue;
                //}

                sales.Add(sale);
            }

            context.AddRange(sales);
            context.SaveChanges();

            return $"Successfully imported {sales.Count}.";
        }

        public static string GetOrderedCustomers(CarDealerContext context)
        {
            var customers = context.Customers
                .OrderBy(c => c.BirthDate)
                .ThenBy(c => c.IsYoungDriver)
                .ProjectTo<ExportCustomerDto>()
                .ToArray();
            
            var stringRepresentation = JsonConvert.SerializeObject(customers, Formatting.Indented);

            return stringRepresentation;
        }

        public static string GetCarsFromMakeToyota(CarDealerContext context)
        {
            var toyotaCars = context.Cars
                .Where(c => c.Make == "Toyota")
                .OrderBy(c => c.Model)
                .ThenByDescending(c => c.TravelledDistance)
                .ProjectTo<ExportToyotaCarDto>()
                .ToArray();

            var stringRepresentation = JsonConvert.SerializeObject(toyotaCars, Formatting.Indented);

            return stringRepresentation;
        }

        public static string GetLocalSuppliers(CarDealerContext context)
        {
            var suppliers = context.Suppliers
                .Where(s => !s.IsImporter)
                .ProjectTo<ExportSupplierDto>()
                .ToArray();

            var stringRepresentation = JsonConvert.SerializeObject(suppliers,Formatting.Indented);

            return stringRepresentation;
        }

        public static string GetCarsWithTheirListOfParts(CarDealerContext context)
        {
            var carsWithParts = context.Cars
                .Select(c => new ExportCarWithPartDto
                {
                    Car = new ExportCarInfoDto
                    {
                        Make = c.Make,
                        Model = c.Model,
                        TravelledDistance = c.TravelledDistance
                    },
                    Parts = c.PartCars.Select(pc => new ExportPartDto
                    {
                        Name = pc.Part.Name,
                        Price = pc.Part.Price.ToString("F2")
                    })
                    .ToArray()
                })
                .ToArray();

            var stringRepresentation = JsonConvert.SerializeObject(carsWithParts,Formatting.Indented);

            return stringRepresentation;
        }

        public static string GetTotalSalesByCustomer(CarDealerContext context)
        {
            //var customer = context.Customers
            //    .Where(c => c.Sales.Count > 1)
            //    .ProjectTo<ExportCustomerSaleDto>()
            //    .OrderByDescending(s=>s.SpendMoney)
            //    .ThenByDescending(s => s.BoughtCars)
            //    .ToArray();

            var customer = context.Customers
                .Where(c => c.Sales.Count > 0)
                .Select(c => new ExportCustomerSaleDto
                {
                    Name = c.Name,
                    BoughtCars = c.Sales.Count,
                    SpendMoney = c.Sales.Sum(x => x.Car.PartCars.Sum(x => x.Part.Price))
                })
                .OrderByDescending(s => s.SpendMoney)
                .ThenByDescending(s => s.BoughtCars)
                .ToArray();

            var stringRepresentation = JsonConvert.SerializeObject(customer, Formatting.Indented);

            return stringRepresentation;
        }

        public static string GetSalesWithAppliedDiscount(CarDealerContext context)
        {
            var sales = context.Sales
                .Select(s => new ExportCarSalesDto
                {
                    Car = new ExportCarInfoDto
                    {
                        Make = s.Car.Make,
                        Model = s.Car.Model,
                        TravelledDistance = s.Car.TravelledDistance
                    },
                    CustomerName = s.Customer.Name,
                    Discount = s.Discount.ToString("F2"),
                    Price = s.Car.PartCars.Sum(pc=>pc.Part.Price).ToString("F2")
                })
                .Take(10)
                .ToArray();

            var stringRepresentation = JsonConvert.SerializeObject(sales,Formatting.Indented);

            return stringRepresentation;
        }
    }
}
