using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Text;

namespace _05_Change_Town_Names_Casing
{
    internal class StartUp
    {
        static void Main(string[] args)
        {
            var country = Console.ReadLine();

            using var connection = new SqlConnection(Config.connectionStr);
            connection.Open();

            var allTownsByCountry = new SqlCommand(Command.searchCountryByName,connection);
            allTownsByCountry.Parameters.AddWithValue("@countryName", country);

            var countTownsByCountry = allTownsByCountry.ExecuteScalar();

            if (countTownsByCountry == null)
            {
                Console.WriteLine("No town names were affected.");
            }
            else
            {
                var upperCommand = new SqlCommand(Command.updateNameTawns, connection);
                upperCommand.Parameters.AddWithValue("@countryName", country);
                upperCommand.ExecuteNonQuery();

                var countAffectedTown = 0;
                var listOfTowns = new List<string>();

                using var readerTown = new SqlCommand(Command.searchCountryByName, connection);
                readerTown.Parameters.AddWithValue("@countryName", country);
                var reader = readerTown.ExecuteReader();

                while (reader.Read())
                {
                    listOfTowns.Add((string)reader["Name"]);
                    countAffectedTown++;
                    
                }
                Console.WriteLine($"{countAffectedTown} town names were affected.");
                Console.WriteLine($"[{string.Join(", ", listOfTowns)}]");

                reader.Close();
            }

            connection.Close();
        }
    }
}
