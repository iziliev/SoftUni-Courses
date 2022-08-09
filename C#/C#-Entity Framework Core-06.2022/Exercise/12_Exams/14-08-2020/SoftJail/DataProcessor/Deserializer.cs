namespace SoftJail.DataProcessor
{

    using Data;
    using Newtonsoft.Json;
    using SoftJail.Data.Models;
    using SoftJail.Data.Models.Enums;
    using SoftJail.DataProcessor.ImportDto;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Globalization;
    using System.Linq;
    using System.Text;
    using static SoftJail.Data.XmlHelper;

    public class Deserializer
    {
        private static string ErrorMessage = "Invalid Data";

        private static string SuccseedImportDepartment = "Imported {0} with {1} cells";

        private static string SuccseedImportPrisoner = "Imported {0} {1} years old";

        private static string SuccseedImportOfficer = "Imported {0} ({1} prisoners)";

        public static string ImportDepartmentsCells(SoftJailDbContext context, string jsonString)
        {
            var sb = new StringBuilder();

            var departmentsDto = JsonConvert.DeserializeObject<ImportDepartmentDto[]>(jsonString);

            var departments = new List<Department>();

            foreach (var departmentDto in departmentsDto)
            {
                if (!IsValid(departmentDto))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                var d = new Department
                {
                    Name = departmentDto.Name
                };

                var isCellValid = true;

                foreach (var cellDto in departmentDto.Cells)
                {
                    if (!IsValid(cellDto))
                    {
                        isCellValid = false;
                        break;
                    }

                    d.Cells.Add(new Cell
                    {
                        CellNumber = cellDto.CellNumber,
                        HasWindow = cellDto.HasWindow
                    });
                }

                if (!isCellValid)
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                if (d.Cells.Count == 0)
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                departments.Add(d);
                sb.AppendLine(string.Format(SuccseedImportDepartment, d.Name, d.Cells.Count));
            }

            context.AddRange(departments);
            context.SaveChanges();

            return sb.ToString().Trim();
        }

        public static string ImportPrisonersMails(SoftJailDbContext context, string jsonString)
        {
            var sb = new StringBuilder();

            var prisonersDto = JsonConvert.DeserializeObject<ImportPrisonerDto[]>(jsonString);

            var prisoners = new List<Prisoner>();

            foreach (var prisonerDto in prisonersDto)
            {
                if (!IsValid(prisonerDto))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                DateTime incarcerationDate;
                var isIncarcerationDateValid = DateTime.TryParseExact(prisonerDto.IncarcerationDate, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out incarcerationDate);

                if (!isIncarcerationDateValid)
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                DateTime? releaseDate = null;
                if (!string.IsNullOrEmpty(prisonerDto.ReleaseDate))
                {
                    DateTime releaseDateValue;
                    var isReleaseDateValid = DateTime.TryParseExact(prisonerDto.ReleaseDate, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out releaseDateValue);

                    if (!isReleaseDateValid)
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }

                    releaseDate = releaseDateValue;
                }

                var p = new Prisoner
                {
                    FullName = prisonerDto.FullName,
                    Nickname = prisonerDto.Nickname,
                    Age = prisonerDto.Age,
                    IncarcerationDate = incarcerationDate,
                    ReleaseDate = releaseDate,
                    Bail = prisonerDto.Bail,
                    CellId = prisonerDto.CellId
                };

                var isMailCorrect = true;
                foreach (var mailDto in prisonerDto.Mails)
                {
                    if (!IsValid(mailDto))
                    {
                        isMailCorrect = false;
                        break;
                    }

                    p.Mails.Add(new Mail
                    {
                        Description = mailDto.Description,
                        Sender = mailDto.Sender,
                        Address = mailDto.Address
                    });
                }

                if (!isMailCorrect)
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                prisoners.Add(p);
                sb.AppendLine(string.Format(SuccseedImportPrisoner, p.FullName, p.Age));
            }

            context.AddRange(prisoners);
            context.SaveChanges();

            return sb.ToString().Trim();
        }

        public static string ImportOfficersPrisoners(SoftJailDbContext context, string xmlString)
        {
            var sb = new StringBuilder();

            var officersDto = XmlConverter.Deserializer<ImportOfficerDto>(xmlString, "Officers");

            var officers = new List<Officer>();

            foreach (var officerDto in officersDto)
            {
                if (!IsValid(officerDto))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                object positionValue;
                var isPositionValid = Enum.TryParse(typeof(Position), officerDto.Position, out positionValue);

                if (!isPositionValid)
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                object weaponValue;
                var isWeaponValid = Enum.TryParse(typeof(Weapon), officerDto.Weapon, out weaponValue);

                if (!isWeaponValid)
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                var department = context.Departments
                    .FirstOrDefault(d => d.Id == officerDto.DepartmentId);

                var o = new Officer
                {
                    FullName = officerDto.Name,
                    Salary = officerDto.Money,
                    Position = (Position)positionValue,
                    Weapon = (Weapon)weaponValue,
                    Department = department,
                };

                foreach (var prisonerDto in officerDto.Prisoners)
                {
                    var prisoner = context.Prisoners
                        .FirstOrDefault(p => p.Id == prisonerDto.Id);

                    o.OfficerPrisoners.Add(new OfficerPrisoner
                    {
                        Prisoner = prisoner,
                        Officer = o
                    });
                }

                officers.Add(o);
                sb.AppendLine(string.Format(SuccseedImportOfficer, o.FullName, o.OfficerPrisoners.Count));
            }

            context.AddRange(officers);
            context.SaveChanges();

            return sb.ToString().Trim();
        }

        private static bool IsValid(object obj)
        {
            var validationContext = new System.ComponentModel.DataAnnotations.ValidationContext(obj);
            var validationResult = new List<ValidationResult>();

            bool isValid = Validator.TryValidateObject(obj, validationContext, validationResult, true);
            return isValid;
        }
    }
}