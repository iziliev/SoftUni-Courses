using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;

namespace _07_Print_All_Minion_Names
{
    public class StartUp
    {
        public static void Main()
        {
            using var connection = new SqlConnection(Config.connectionStr);
            connection.Open();

            var commandMinion = new SqlCommand(Command.searchMinionsName, connection);
            using var reader = commandMinion.ExecuteReader();

            var minions = new List<string>();

            while (reader.Read())
            {
                minions.Add((string)reader["Name"]);
            }

            for (int i = 0; i < minions.Count / 2; i++)
            {
                Console.WriteLine(minions[i]);
                Console.WriteLine(minions[minions.Count - 1 - i]);
            }
            if (minions.Count % 2 != 0)
            {
                Console.WriteLine(minions[minions.Count / 2]);
            }

            connection.Close();
        }
    }
}
