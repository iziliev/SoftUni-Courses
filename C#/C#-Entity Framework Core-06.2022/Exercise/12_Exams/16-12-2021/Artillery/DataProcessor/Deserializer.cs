namespace Artillery.DataProcessor
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Xml.Serialization;
    using Artillery.Data;
    using Artillery.Data.Models;
    using Artillery.Data.Models.Enums;
    using Artillery.DataProcessor.ImportDto;
    using Newtonsoft.Json;
    using static Artillery.Data.XmlHelper;

    public class Deserializer
    {
        private const string ErrorMessage =
                "Invalid data.";
        private const string SuccessfulImportCountry =
            "Successfully import {0} with {1} army personnel.";
        private const string SuccessfulImportManufacturer =
            "Successfully import manufacturer {0} founded in {1}.";
        private const string SuccessfulImportShell =
            "Successfully import shell caliber #{0} weight {1} kg.";
        private const string SuccessfulImportGun =
            "Successfully import gun {0} with a total weight of {1} kg. and barrel length of {2} m.";

        public static string ImportCountries(ArtilleryContext context, string xmlString)
        {
            var sb = new StringBuilder();

            var countriesDto = XmlConverter.Deserializer<ImportCountryDto>(xmlString, "Countries");

            var countries = new List<Country>();

            foreach (var countryDto in countriesDto)
            {
                if (!IsValid(countryDto))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                var c = new Country
                {
                    CountryName = countryDto.CountryName,
                    ArmySize = countryDto.ArmySize
                };

                countries.Add(c);

                sb.AppendLine(String.Format(SuccessfulImportCountry, c.CountryName, c.ArmySize));
            }

            context.AddRange(countries);
            context.SaveChanges();

            return sb.ToString().Trim();
        }

        public static string ImportManufacturers(ArtilleryContext context, string xmlString)
        {
            var sb = new StringBuilder();

            var manufacturersDto = XmlConverter.Deserializer<ImportManufacturerDto>(xmlString, "Manufacturers");

            var manufacturers = new List<Manufacturer>();

            foreach (var manufacturerDto in manufacturersDto)
            {
                if (!IsValid(manufacturerDto))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                var manufacturer = manufacturers.FirstOrDefault(m=>m.ManufacturerName == manufacturerDto.ManufacturerName);

                if (manufacturer!=null)
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                var founded = manufacturerDto.Founded
                    .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                    .TakeLast(2)
                    .ToArray();

                var townCity = string.Join(", ", founded);

                var m = new Manufacturer
                {
                    ManufacturerName = manufacturerDto.ManufacturerName,
                    Founded = manufacturerDto.Founded
                };

                manufacturers.Add(m);

                sb.AppendLine(string.Format(SuccessfulImportManufacturer, m.ManufacturerName, townCity));
            }

            context.AddRange(manufacturers);
            context.SaveChanges();

            return sb.ToString().Trim();
        }

        public static string ImportShells(ArtilleryContext context, string xmlString)
        {
            var sb = new StringBuilder();

            var shellsDto = XmlConverter.Deserializer<ImportShellDto>(xmlString, "Shells");

            var shells = new List<Shell>();

            foreach (var shellDto in shellsDto)
            {
                if (!IsValid(shellDto))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                var s = new Shell
                {
                    ShellWeight = shellDto.ShellWeight,
                    Caliber = shellDto.Caliber
                };

                shells.Add(s);

                sb.AppendLine(string.Format(SuccessfulImportShell,s.Caliber, s.ShellWeight));
            }

            context.AddRange(shells);
            context.SaveChanges();

            return sb.ToString().Trim();
        }

        public static string ImportGuns(ArtilleryContext context, string jsonString)
        {
            var sb = new StringBuilder();

            var gunsDto = JsonConvert.DeserializeObject<ImportGunDto[]>(jsonString);

            var guns = new List<Gun>();

            foreach (var gunDto in gunsDto)
            {
                if (!IsValid(gunDto))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                GunType gunType;
                var isValidType = Enum.TryParse(gunDto.GunType, out gunType);

                if (!isValidType)
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                var g = new Gun
                {
                    ManufacturerId = gunDto.ManufacturerId,
                    GunWeight = gunDto.GunWeight,
                    BarrelLength = gunDto.BarrelLength,
                    NumberBuild = gunDto.NumberBuild,
                    Range = gunDto.Range,
                    GunType = gunType,
                    ShellId = gunDto.ShellId
                };

                foreach (var country in gunDto.Countries)
                {
                    g.CountriesGuns.Add(new CountryGun
                    {
                        CountryId = country.Id,
                        Gun = g
                    });;
                }

                guns.Add(g);

                sb.AppendLine(string.Format(SuccessfulImportGun, g.GunType, g.GunWeight, g.BarrelLength));
            }

            context.AddRange(guns);
            context.SaveChanges();

            return sb.ToString().Trim();

        }

        private static bool IsValid(object obj)
        {
            var validator = new ValidationContext(obj);
            var validationRes = new List<ValidationResult>();

            var result = Validator.TryValidateObject(obj, validator, validationRes, true);
            return result;
        }
    }
}
