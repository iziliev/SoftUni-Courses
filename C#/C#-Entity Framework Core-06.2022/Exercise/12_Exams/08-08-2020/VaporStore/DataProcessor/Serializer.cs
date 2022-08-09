namespace VaporStore.DataProcessor
{
	using System;
    using System.Globalization;
    using System.Linq;
    using Data;
    using Newtonsoft.Json;
    using VaporStore.Data.Models.Enums;
    using VaporStore.DataProcessor.Dto.Export;
    using static VaporStore.Data.XmlHelper;

    public static class Serializer
	{
		public static string ExportGamesByGenres(VaporStoreDbContext context, string[] genreNames)
		{
			var games = context.Genres
				.Where(g => genreNames.Contains(g.Name))
                .ToArray()
                .Select(g => new
                {
                    Id = g.Id,
                    Genre = g.Name,
                    Games = g.Games
                    .Where(gam => gam.Purchases.Any())
                    .Select(gam => new
                    {
                        Id = gam.Id,
                        Title = gam.Name,
                        Developer = gam.Developer.Name,
                        Tags = string.Join(", ", gam.GameTags.Select(t => t.Tag.Name)),
                        Players = gam.Purchases.Count()
                    })
                    .OrderByDescending(g => g.Players)
                    .ThenBy(g => g.Id)
                    .ToArray(),
                    TotalPlayers = g.Games.Sum(s => s.Purchases.Count)
                })
                .OrderByDescending(x=>x.TotalPlayers)
                .ThenBy(x=>x.Id)
                .ToArray();

			var stringRepresentation = JsonConvert.SerializeObject(games, Formatting.Indented);

			return stringRepresentation;
		}

		public static string ExportUserPurchasesByType(VaporStoreDbContext context, string storeType)
		{
            var users = context.Users
                .ToArray()
                .Where(u => u.Cards.Any(x => x.Purchases.Any(p => p.Type.ToString() == storeType)))
                .Select(u => new ExportUserDto
                {
                    UserName = u.Username,
                    Purchases = u.Cards.SelectMany(x => x.Purchases).Where(y => y.Type.ToString() == storeType)
                    .OrderBy(x=>x.Date)
                    .Select(p => new ExportPurchaseDto
                    {
                        Card = p.Card.Number,
                        Cvc = p.Card.Cvc,
                        Date = p.Date.ToString("yyyy-MM-dd HH:mm", CultureInfo.InvariantCulture),
                        Game = new ExportGameDto
                        {
                            Title = p.Game.Name,
                            Genre = p.Game.Genre.Name,
                            Price = p.Game.Price
                        }
                    })
                    .ToArray(),
                    TotalSpent = u.Cards.Sum(c=>c.Purchases.Where(p=>p.Type.ToString() == storeType).Sum(p=>p.Game.Price))
                })
                .OrderByDescending(u=>u.TotalSpent)
                .ThenBy(u=>u.UserName)
                .ToArray();

            var stringRepresentation = XmlConverter.Serialize(users, "Users");

            return stringRepresentation;
		}
	}
}