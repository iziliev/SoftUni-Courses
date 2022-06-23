using Microsoft.Data.SqlClient;
using System;
using System.Linq;

namespace _08_Increase_Minion_Age
{
    public class StartUp
    {
        public static void Main()
        {
            var ids = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            using var connection = new SqlConnection(Config.connectionStr);
            connection.Open();

            for (int i = 0; i < ids.Length; i++)
            {
                var command = new SqlCommand(Command.increaseAgeOnMinion, connection);
                command.Parameters.AddWithValue("@Id", ids[i]);
                command.ExecuteNonQuery();
            }

            var showMinion = new SqlCommand(Command.selectMinion, connection);
            using var reader = showMinion.ExecuteReader();

            while (reader.Read())
            {
                Console.WriteLine($"{reader["Name"]} {reader["Age"]}");
            }

            reader.Close();
            connection.Close();
        }
    }
}
