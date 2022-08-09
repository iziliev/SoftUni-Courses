namespace SoftJail.DataProcessor
{

    using Data;
    using Newtonsoft.Json;
    using SoftJail.DataProcessor.ExportDto;
    using System;
    using System.Globalization;
    using System.Linq;
    using static SoftJail.Data.XmlHelper;

    public class Serializer
    {
        public static string ExportPrisonersByCells(SoftJailDbContext context, int[] ids)
        {
            var prisoner = context.Prisoners
                .Where(p => ids.Contains(p.Id))
                .OrderBy(p => p.FullName)
                .ThenBy(p => p.Id)
                .Select(p => new ExportPrisonerOfficerDto
                {
                    Id = p.Id,
                    Name = p.FullName,
                    CellNumber = p.Cell.CellNumber,
                    Officers = p.PrisonerOfficers.Select(po => new ExportOfficerDto
                    {
                        OfficerName = po.Officer.FullName,
                        Department = po.Officer.Department.Name
                    })
                    .OrderBy(o => o.OfficerName)
                    .ToArray(),
                    TotalOfficerSalary = Math.Round(p.PrisonerOfficers.Sum(po => po.Officer.Salary),2)
                })
                .ToArray();

            var stringRepresentation = JsonConvert.SerializeObject(prisoner, Formatting.Indented);

            return stringRepresentation;
        }

        public static string ExportPrisonersInbox(SoftJailDbContext context, string prisonersNames)
        {
            var prisonersArr = prisonersNames
                .Split(",", StringSplitOptions.RemoveEmptyEntries)
                .ToArray();

            var prisoners = context.Prisoners
                .Where(p => prisonersArr.Contains(p.FullName))
                .OrderBy(p => p.FullName)
                .ThenBy(p => p.Id)
                .Select(p => new ExportPrisonerMailDto
                {
                    Id = p.Id,
                    Name = p.FullName,
                    IncarcerationDate = p.IncarcerationDate.ToString("yyyy-MM-dd", CultureInfo.InvariantCulture),
                    EncryptedMessages = p.Mails.Select(m => new ExportMailDto
                    {
                        Description = new string(m.Description.ToCharArray().Reverse().ToArray())
                    })
                    .ToArray()
                })
                .ToArray();

            var stringRepresentation = XmlConverter.Serialize(prisoners, "Prisoners");

            return stringRepresentation;

        }
    }
}