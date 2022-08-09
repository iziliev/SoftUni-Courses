namespace Theatre.DataProcessor
{
    using Newtonsoft.Json;
    using System;
    using System.Linq;
    using Theatre.Data;
    using Theatre.DataProcessor.ExportDto;

    public class Serializer
    {
        public static string ExportTheatres(TheatreContext context, int numbersOfHalls)
        {
            var theatres = context.Theatres
                .ToArray()
                .Where(t => t.NumberOfHalls >= numbersOfHalls && t.Tickets.Count >= 20)
                .Select(t => new ExportTheatreDto
                {
                    Name = t.Name,
                    Halls = t.NumberOfHalls,
                    TotalIncome = t.Tickets.Where(x => x.RowNumber >= 1 && x.RowNumber <= 5).Sum(x => x.Price),
                    Tickets = t.Tickets
                    .Where(x => x.RowNumber >= 1 && x.RowNumber <= 5)
                    .Select(x => new ExportTicketDto
                    {
                        Price = x.Price,
                        RowNumber = x.RowNumber
                    })
                    .OrderByDescending(x => x.Price)
                    .ToArray()
                })
                .OrderByDescending(x => x.Halls)
                .ThenBy(x => x.Name)
                .ToArray();

            var stringRepresentation = JsonConvert.SerializeObject(theatres,Formatting.Indented);

            return stringRepresentation;
        }

        public static string ExportPlays(TheatreContext context, double rating)
        {
            var plays = context.Plays
                .ToArray()
                .Where(p => p.Rating <= rating)
                .Select(p => new ExportPlayDto
                {
                    Title = p.Title,
                    Duration = p.Duration.ToString("c"),
                    Rating = p.Rating == 0 ? "Premier" : p.Rating.ToString(),
                    Genre = p.Genre.ToString(),
                    Actors = p.Casts
                    .Where(c => c.IsMainCharacter)
                    .Select(c => new ExportCastDto
                    {
                        FullName = c.FullName,
                        MainCharacter = $"Plays main character in '{p.Title}'."
                    })
                    .OrderByDescending(a => a.FullName)
                    .ToArray()
                })
                .OrderBy(p => p.Title)
                .ThenByDescending(p => p.Genre)
                .ToArray();

            return Helper.XmlSerialise(plays, "Plays");
        }
    }
}
