namespace Footballers.DataProcessor
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Globalization;
    using System.Linq;
    using System.Text;
    using Data;
    using Footballers.Data.Models;
    using Footballers.Data.Models.Enums;
    using Footballers.DataProcessor.ImportDto;
    using Newtonsoft.Json;

    public class Deserializer
    {
        private const string ErrorMessage = "Invalid data!";

        private const string SuccessfullyImportedCoach
            = "Successfully imported coach - {0} with {1} footballers.";

        private const string SuccessfullyImportedTeam
            = "Successfully imported team - {0} with {1} footballers.";

        public static string ImportCoaches(FootballersContext context, string xmlString)
        {
            var sb = new StringBuilder();

            var coachesDto = XmlConverter.Deserializer<ImportCoachDto>(xmlString, "Coaches");

            var coaches = new List<Coach>();

            foreach (var coachDto in coachesDto)
            {
                if (!IsValid(coachDto))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                var c = new Coach
                {
                    Name = coachDto.Name,
                    Nationality = coachDto.Nationality
                };

                foreach (var footballerDto in coachDto.Footballers)
                {
                    if (!IsValid(footballerDto))
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }

                    DateTime startDate;
                    var isStartDateValid = DateTime.TryParseExact(footballerDto.ContractStartDate, "dd/MM/yyyy", CultureInfo.InvariantCulture,DateTimeStyles.None, out startDate);

                    if (!isStartDateValid)
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }

                    DateTime endDate;
                    var isEndDateValid = DateTime.TryParseExact(footballerDto.ContractEndDate, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out endDate);

                    if (!isEndDateValid)
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }

                    if (startDate>endDate)
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }

                    object position;
                    var isValidPosition = Enum.TryParse(typeof(PositionType), footballerDto.PositionType, out position);

                    if (!isValidPosition)
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }

                    object skill;
                    var isValidSkill = Enum.TryParse(typeof(BestSkillType), footballerDto.BestSkillType, out skill);

                    if (!isValidSkill)
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }

                    c.Footballers.Add(new Footballer
                    {
                        Name = footballerDto.Name,
                        ContractStartDate = startDate,
                        ContractEndDate = endDate,
                        PositionType = (PositionType)position,
                        BestSkillType = (BestSkillType)skill
                    });
                }

                coaches.Add(c);
                sb.AppendLine(string.Format(SuccessfullyImportedCoach, c.Name, c.Footballers.Count));
            }

            context.AddRange(coaches);
            context.SaveChanges();

            return sb.ToString().Trim();
        }

        public static string ImportTeams(FootballersContext context, string jsonString)
        {
            var sb = new StringBuilder();

            var teamsDto = JsonConvert.DeserializeObject<ImportTeamDto[]>(jsonString);

            var teams = new List<Team>();

            foreach (var teamDto in teamsDto)
            {
                if (!IsValid(teamDto))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                var isValidInt = int.TryParse(teamDto.Trophies, out int trophies);

                if (trophies <= 0 || !isValidInt)
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                var t = new Team
                {
                    Name = teamDto.Name,
                    Nationality = teamDto.Nationality,
                    Trophies = int.Parse(teamDto.Trophies)
                };

                foreach (var footballerDto in teamDto.Footballers)
                {
                    var f = context.Footballers.FirstOrDefault(f => f.Id == footballerDto);

                    if (f == null)
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }

                    t.TeamsFootballers.Add(new TeamFootballer
                    {
                        Footballer = f
                    });
                }

                teams.Add(t);
                sb.AppendLine(string.Format(SuccessfullyImportedTeam,t.Name,t.TeamsFootballers.Count));
            }

            context.AddRange(teams);
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
