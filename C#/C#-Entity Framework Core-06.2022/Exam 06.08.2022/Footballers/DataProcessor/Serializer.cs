namespace Footballers.DataProcessor
{
    using System;
    using System.Globalization;
    using System.Linq;
    using Data;
    using Footballers.DataProcessor.ExportDto;
    using Newtonsoft.Json;
    using Formatting = Newtonsoft.Json.Formatting;

    public class Serializer
    {
        public static string ExportCoachesWithTheirFootballers(FootballersContext context)
        {
            var coaches = context.Coaches
                .Where(c => c.Footballers.Count > 0)
                .ToArray()
                .Select(c => new ExportCoachDto
                {
                    FootballersCount = c.Footballers.Count,
                    CoachName = c.Name,
                    Footballers = c.Footballers.Select(f => new ExportFootballerWithPositionDto
                    {
                        Name = f.Name,
                        Position = f.PositionType.ToString()
                    })
                    .OrderBy(f => f.Name)
                    .ToArray()
                })
                .OrderByDescending(c => c.FootballersCount)
                .ThenBy(c => c.CoachName)
                .ToArray();

            var stringRepresentation = XmlConverter.Serialize(coaches, "Coaches");

            return stringRepresentation;
        }

        public static string ExportTeamsWithMostFootballers(FootballersContext context, DateTime date)
        {
            var teams = context.Teams
                .Where(t => t.TeamsFootballers.Any(f => f.Footballer.ContractStartDate >= date))
                .ToArray()
                .Select(t => new ExportTeamDto
                 {
                     Name = t.Name,
                     Footballers = t.TeamsFootballers
                    .Where(f => f.Footballer.ContractStartDate >= date)
                    .OrderByDescending(f => f.Footballer.ContractEndDate)
                    .ThenBy(f => f.Footballer.Name)
                    .Select(ft => new ExportFootballerDto
                    {
                        FootballerName = ft.Footballer.Name,
                        ContractStartDate = ft.Footballer.ContractStartDate.ToString("d", CultureInfo.InvariantCulture),
                        ContractEndDate = ft.Footballer.ContractEndDate.ToString("d", CultureInfo.InvariantCulture),
                        BestSkillType = ft.Footballer.BestSkillType.ToString(),
                        PositionType = ft.Footballer.PositionType.ToString()
                    })
                    .ToArray()
                 })
                .OrderByDescending(t => t.Footballers.Count())
                .ThenBy(t => t.Name)
                .Take(5)
                .ToArray();

            var stringRepresentation = JsonConvert.SerializeObject(teams,Formatting.Indented);

            return stringRepresentation;
        }
    }
}
