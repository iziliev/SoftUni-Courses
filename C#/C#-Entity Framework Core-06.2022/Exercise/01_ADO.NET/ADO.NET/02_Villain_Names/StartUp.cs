using Microsoft.Data.SqlClient;
using System;

namespace _02_Villain_Names
{
    public class StartUp
    {
        public static void Main()
        {
            using var connection = new SqlConnection(Config.connectionStr);
            connection.Open();

            var command = new SqlCommand(Command.query,connection);

            using var reader = command.ExecuteReader();

            while (reader.Read())
            {
                Console.WriteLine($"{reader["Name"]} - {reader["MinionsCount"]}");
            }
            reader.Close();
            connection.Close();
        }
    }
}
