namespace Trucks.DataProcessor
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using System.Text;
    using Data;
    using Newtonsoft.Json;
    using Trucks.Data.Models;
    using Trucks.Data.Models.Enums;
    using Trucks.DataProcessor.ImportDto;

    public class Deserializer
    {
        private const string ErrorMessage = "Invalid data!";

        private const string SuccessfullyImportedDespatcher
            = "Successfully imported despatcher - {0} with {1} trucks.";

        private const string SuccessfullyImportedClient
            = "Successfully imported client - {0} with {1} trucks.";

        public static string ImportDespatcher(TrucksContext context, string xmlString)
        {
            var sb = new StringBuilder();

            var despatchersDto = XmlConverter.Deserializer<ImportDespatcherDto>(xmlString, "Despatchers");

            var despatchers = new List<Despatcher>();

            foreach (var despatcherDto in despatchersDto)
            {
                if (!IsValid(despatcherDto))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                var d = new Despatcher
                {
                    Name = despatcherDto.Name,
                    Position = despatcherDto.Position,
                };

                foreach (var truckDto in despatcherDto.Trucks)
                {
                    if (!IsValid(truckDto))
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }

                    var isValidCategory = Enum.TryParse<CategoryType>(truckDto.CategoryType, out CategoryType typeCategory);

                    if (!isValidCategory)
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }

                    var isValidType = Enum.TryParse<MakeType>(truckDto.MakeType, out MakeType makeType);

                    if (!isValidType)
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }

                    var t = new Truck
                    {
                        RegistrationNumber = truckDto.RegistrationNumber,
                        VinNumber = truckDto.VinNumber,
                        TankCapacity = truckDto.TankCapacity,
                        CargoCapacity = truckDto.CargoCapacity,
                        CategoryType = typeCategory,
                        MakeType = makeType
                    };

                    d.Trucks.Add(t);
                }

                despatchers.Add(d);
                sb.AppendLine(string.Format(SuccessfullyImportedDespatcher, d.Name, d.Trucks.Count));
            }
            context.AddRange(despatchers);
            context.SaveChanges();

            return sb.ToString().Trim();
        }

        public static string ImportClient(TrucksContext context, string jsonString)
        {
            var sb = new StringBuilder();

            var clientsDto = JsonConvert.DeserializeObject<ImportClientDto[]>(jsonString);

            var clients = new List<Client>();

            foreach (var clientDto in clientsDto)
            {
                if (!IsValid(clientDto))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                if (clientDto.Type == "usual")
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                var c = new Client
                {
                    Name = clientDto.Name,
                    Nationality = clientDto.Nationality,
                    Type = clientDto.Type,
                };

                foreach (var truckId in clientDto.Trucks.Distinct())
                {
                    var t = context.Trucks.FirstOrDefault(t => t.Id == truckId);

                    if (t == null)
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }

                    var ct = new ClientTruck
                    {
                        TruckId = t.Id
                    };

                    c.ClientsTrucks.Add(ct);
                }

                clients.Add(c);

                sb.AppendLine(string.Format(SuccessfullyImportedClient, c.Name, c.ClientsTrucks.Count));
            }

            context.AddRange(clients);
            context.SaveChanges();

            return sb.ToString().Trim();
        }

        private static bool IsValid(object dto)
        {
            var validationContext = new ValidationContext(dto);
            var validationResult = new List<ValidationResult>();

            return Validator.TryValidateObject(dto, validationContext, validationResult, true);
        }
    }
}
