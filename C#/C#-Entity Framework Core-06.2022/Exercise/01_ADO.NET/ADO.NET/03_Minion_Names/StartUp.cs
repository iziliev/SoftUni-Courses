using Microsoft.Data.SqlClient;
using System;

namespace _03_Minion_Names
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            using var connection = new SqlConnection(Config.connectionStr);
            connection.Open();

            var vilainId = int.Parse(Console.ReadLine());

            var cmdVilainName = new SqlCommand(Command.getVillainNameQuery, connection);
            cmdVilainName.Parameters.AddWithValue("@Id", vilainId);
            var vilainName = (string)cmdVilainName.ExecuteScalar();

            if (vilainName==null)
            {
                Console.WriteLine($"No villain with ID {vilainId} exists in the database.");
            }
            else
            {
                var cmdMinionsName = new SqlCommand(Command.getMinionsQuery, connection);
                cmdMinionsName.Parameters.AddWithValue("@Id", vilainId);
                using var reader = cmdMinionsName.ExecuteReader();

                Console.WriteLine($"Villain: {vilainName}");

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        Console.WriteLine($"{reader["RowNum"]}. {reader["Name"]} {reader["Age"]}");
                    }
                }
                else
                {
                    Console.WriteLine("(no minions)");
                }

                reader.Close();
            }
            connection.Close();
        }
    }
}
