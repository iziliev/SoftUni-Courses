namespace _05_Change_Town_Names_Casing
{
    public static class Command
    {
        public static string searchCountryByName = @"SELECT t.[Name] 
                                                        FROM [Towns] as t 
                                                        JOIN [Countries] AS c ON c.[Id] = t.[CountryCode]
                                                        WHERE c.[Name] = @countryName";

        public static string updateNameTawns = @"UPDATE [Towns]
                                               SET [Name] = UPPER([Name])
                                             WHERE [CountryCode] = (
                                                                    SELECT c.[Id] 
                                                                        FROM [Countries] AS c 
                                                                        WHERE c.[Name] = @countryName
                                                                    )";
    }
}
