namespace VaporStore.DataProcessor
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Globalization;
    using System.Linq;
    using System.Text;
    using Data;
    using Newtonsoft.Json;
    using VaporStore.Data.Models;
    using VaporStore.Data.Models.Enums;
    using VaporStore.DataProcessor.Dto.Import;
    using static VaporStore.Data.XmlHelper;

    public static class Deserializer
    {
        private static string ErrorMessage = "Invalid Data";

        private static string ImportGamesMessage = "Added {0} ({1}) with {2} tags";

        private static string ImportUsersMessage = "Imported {0} with {1} cards";

        private static string ImportPurchaseMessage = "Imported {0} for {1}";

        public static string ImportGames(VaporStoreDbContext context, string jsonString)
        {
            var sb = new StringBuilder();

            var gamesDto = JsonConvert.DeserializeObject<ImportGameDto[]>(jsonString);

            var games = new List<Game>();

            foreach (var gameDto in gamesDto)
            {
                if (!IsValid(gameDto))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                if (gameDto.Tags.Length == 0)
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                DateTime releaseDate;
                var isReleaseDateValid = DateTime.TryParseExact(gameDto.ReleaseDate, "yyyy-MM-dd", CultureInfo.InvariantCulture, DateTimeStyles.None, out releaseDate);

                if (!isReleaseDateValid)
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                var d = context.Developers
                    .FirstOrDefault(d => d.Name == gameDto.Developer);

                if (d == null)
                {
                    d = new Developer
                    {
                        Name = gameDto.Developer,
                    };
                }

                var gen = context.Genres
                    .FirstOrDefault(g => g.Name == gameDto.Genre);

                if (gen == null)
                {
                    gen = new Genre
                    {
                        Name = gameDto.Genre,
                    };
                }

                var g = new Game
                {
                    Name = gameDto.Name,
                    Price = gameDto.Price,
                    Developer = d,
                    Genre = gen
                };

                foreach (var tagDto in gameDto.Tags)
                {
                    if (!IsValid(tagDto))
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }

                    var t = context.Tags
                        .FirstOrDefault(t => t.Name == tagDto);

                    if (t == null)
                    {
                        t = new Tag
                        {
                            Name = tagDto
                        };
                    }

                    g.GameTags.Add(new GameTag
                    {
                        Tag = t,
                        Game = g
                    });
                }

                context.Add(g);
                sb.AppendLine(string.Format(ImportGamesMessage, g.Name, g.Genre.Name, g.GameTags.Count));
                context.SaveChanges();
            }

            return sb.ToString().Trim();
        }

        public static string ImportUsers(VaporStoreDbContext context, string jsonString)
        {
            var sb = new StringBuilder();

            var usersDto = JsonConvert.DeserializeObject<ImportUserDto[]>(jsonString);

            var users = new List<User>();

            foreach (var userDto in usersDto)
            {
                if (!IsValid(userDto))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                if (userDto.Cards.Length == 0)
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                var u = new User
                {
                    FullName = userDto.FullName,
                    Username = userDto.Username,
                    Email = userDto.Email,
                    Age = userDto.Age
                };

                foreach (var cardDto in userDto.Cards)
                {
                    if (!IsValid(cardDto))
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }

                    object cardType;
                    var isValidType = Enum.TryParse(typeof(CardType), cardDto.Type, out cardType);

                    if (!isValidType)
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }

                    u.Cards.Add(new Card
                    {
                        Number = cardDto.Number,
                        Cvc = cardDto.Cvc,
                        Type = (CardType)cardType
                    });
                }

                users.Add(u);
                sb.AppendLine(string.Format(ImportUsersMessage, u.Username, u.Cards.Count));
            }

            context.AddRange(users);
            context.SaveChanges();

            return sb.ToString().Trim();
        }

        public static string ImportPurchases(VaporStoreDbContext context, string xmlString)
        {
            var sb = new StringBuilder();

            var purchasesDto = XmlConverter.Deserializer<ImportPurchaseDto>(xmlString, "Purchases");

            var purchases = new List<Purchase>();

            foreach (var purchaseDto in purchasesDto)
            {
                if (!IsValid(purchaseDto))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                object purchaseType;
                var isPurchaseTypeValid = Enum.TryParse(typeof(PurchaseType), purchaseDto.Type, out purchaseType);

                if (!isPurchaseTypeValid)
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                DateTime date;
                var isValidDate = DateTime.TryParseExact(purchaseDto.Date, "dd/MM/yyyy HH:mm", CultureInfo.InvariantCulture, DateTimeStyles.None, out date);

                if (!isValidDate)
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                var p = new Purchase
                {
                    Game = context.Games.FirstOrDefault(g => g.Name == purchaseDto.Title),
                    Type = (PurchaseType)purchaseType,
                    ProductKey = purchaseDto.Key,
                    Card = context.Cards.FirstOrDefault(c => c.Number == purchaseDto.Card),
                    Date = date
                };

                purchases.Add(p);

                sb.AppendLine(string.Format(ImportPurchaseMessage, p.Game.Name, p.Card.User.Username));
            }

            context.AddRange(purchases);
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