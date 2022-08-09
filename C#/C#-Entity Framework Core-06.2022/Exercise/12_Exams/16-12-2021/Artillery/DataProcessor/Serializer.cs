
namespace Artillery.DataProcessor
{
    using Artillery.Data;
    using Artillery.DataProcessor.ExportDto;
    using Newtonsoft.Json;
    using System;
    using System.Linq;
    using static Artillery.Data.XmlHelper;

    public class Serializer
    {
        public static string ExportShells(ArtilleryContext context, double shellWeight)
        {
            var shells = context.Shells
                .Where(s => s.ShellWeight > shellWeight)
                .ToArray()
                .Select(s => new
                {
                    ShellWeight = s.ShellWeight,
                    Caliber = s.Caliber,
                    Guns = s.Guns
                    .Where(g => g.GunType.ToString() == "AntiAircraftGun")
                    .Select(g => new
                    {
                        GunType = "AntiAircraftGun",
                        GunWeight = g.GunWeight,
                        BarrelLength = g.BarrelLength,
                        Range = g.Range > 3000 ? "Long-range" : "Regular range"
                    })
                    .OrderByDescending(g => g.GunWeight)
                    .ToArray()
                })
                .OrderBy(s=>s.ShellWeight)
                .ToArray();

            var stringRepresentation = JsonConvert.SerializeObject(shells, Formatting.Indented);

            return stringRepresentation;
        }

        public static string ExportGuns(ArtilleryContext context, string manufacturer)
        {
            var guns = context.Guns
                .Where(g => g.Manufacturer.ManufacturerName == manufacturer)
                .OrderBy(g => g.BarrelLength)
                .Select(g => new ExportGunDto
                {
                    Manufacturer = g.Manufacturer.ManufacturerName,
                    GunType = g.GunType.ToString(),
                    BarrelLength = g.BarrelLength.ToString(),
                    GunWeight = g.GunWeight.ToString(),
                    Range = g.Range.ToString(),
                    Countries = g.CountriesGuns
                    .Where(cg => cg.Country.ArmySize > 4500000)
                    .OrderBy(cg => cg.Country.ArmySize)
                    .Select(cg => new ExportCountryDto
                    {
                        Country = cg.Country.CountryName,
                        ArmySize = cg.Country.ArmySize.ToString()
                    })
                    .ToArray()
                })
                .ToArray();

            var stringRepresent = XmlConverter.Serialize(guns, "Guns");

            return stringRepresent;
        }
    }
}
