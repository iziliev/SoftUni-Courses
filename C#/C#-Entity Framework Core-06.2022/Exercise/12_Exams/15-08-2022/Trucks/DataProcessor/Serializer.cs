namespace Trucks.DataProcessor
{
    using System;
    using System.Linq;
    using Data;
    using Newtonsoft.Json;
    using Trucks.DataProcessor.ExportDto;
    using Trucks.DataProcessor.ImportDto;
    using Formatting = Newtonsoft.Json.Formatting;

    public class Serializer
    {
        public static string ExportDespatchersWithTheirTrucks(TrucksContext context)
        {
            var despatchers = context.Despatchers
                .Where(d => d.Trucks.Count > 0)
                .ToArray()
                .Select(d => new ExportDespatcherDto
                {
                    TrucksCount = d.Trucks.Count,
                    DespatcherName = d.Name,
                    Trucks = d.Trucks.Select(t => new ExportTrucksDespatcherDto
                    {
                        RegistrationNumber = t.RegistrationNumber,
                        Make = t.MakeType.ToString()
                    })
                    .OrderBy(t => t.RegistrationNumber)
                    .ToArray()
                })
                .OrderByDescending(d => d.TrucksCount)
                .ThenBy(d => d.DespatcherName)
                .ToArray();

            var stringRepresentation = XmlConverter.Serialize(despatchers, "Despatchers");

            return stringRepresentation;
        }

        public static string ExportClientsWithMostTrucks(TrucksContext context, int capacity)
        {
            var clientsDto = context.Clients
                .Where(c => c.ClientsTrucks.Count > 0)
                .ToArray()
                .Select(c => new ExportClientsWithTruckDto
                {
                    Name = c.Name,
                    Trucks = c.ClientsTrucks
                    .Where(t => t.Truck.TankCapacity >= capacity)
                    .Select(t => new ExportTrucksDto
                    {
                        TruckRegistrationNumber = t.Truck.RegistrationNumber,
                        VinNumber = t.Truck.VinNumber,
                        TankCapacity = t.Truck.TankCapacity,
                        CargoCapacity = t.Truck.CargoCapacity,
                        CategoryType = t.Truck.CategoryType.ToString(),
                        MakeType = t.Truck.MakeType.ToString()
                    })
                    .OrderBy(t => t.MakeType)
                    .ThenByDescending(t => t.CargoCapacity)
                    .ToArray()
                })
                .OrderByDescending(c => c.Trucks.Count())
                .ThenBy(t => t.Name)
                .Take(10)
                .ToArray();

            var stringRepresentation = JsonConvert.SerializeObject(clientsDto, Formatting.Indented);

            return stringRepresentation;
        }
    }
}
