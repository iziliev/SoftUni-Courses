using Microsoft.Data.SqlClient;
using System;
using System.Linq;

namespace _04_Add_Minion
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            using var connection = new SqlConnection(Config.connectionStr);
            connection.Open();

            var inputMinionData = Console.ReadLine()
               .Split(" ", StringSplitOptions.RemoveEmptyEntries)
               .ToArray();

            var minionName = inputMinionData[1];
            var minionAge = int.Parse(inputMinionData[2]);
            var minionTown = inputMinionData[3];

            var inputVilain = Console.ReadLine()
               .Split(" ", StringSplitOptions.RemoveEmptyEntries)
               .ToArray();
            var vilainName = inputVilain[1];

            InsertMinionInDB(connection, minionName, minionAge, minionTown, vilainName);
            
            connection.Close();
        }

        private static void InsertMinionInDB(SqlConnection connection, string minionName, int minionAge, string minionTown, string vilainName)
        {
            var commandTown = new SqlCommand(Command.searchTownById, connection);
            commandTown.Parameters.AddWithValue("@townName", minionTown);
            var townId = commandTown.ExecuteScalar();

            if (townId == null)
            {
                var insertTown = new SqlCommand(Command.insertTown, connection);
                insertTown.Parameters.AddWithValue("@townName", minionTown);
                insertTown.ExecuteNonQuery();
                Console.WriteLine($"Town {minionTown} was added to the database.");
            }

            var commandVilain = new SqlCommand(Command.searchVilainsByName, connection);
            commandVilain.Parameters.AddWithValue("@Name", vilainName);
            var idVilain = commandVilain.ExecuteScalar();

            if (idVilain == null)
            {
                var insertVilain = new SqlCommand(Command.insertVilains, connection);
                insertVilain.Parameters.AddWithValue("@villainName", vilainName);
                insertVilain.ExecuteNonQuery();
                Console.WriteLine($"Villain {vilainName} was added to the database.");
            }

            townId = commandTown.ExecuteScalar();

            var insertMinion = new SqlCommand(Command.insertMinion, connection);
            insertMinion.Parameters.AddWithValue("@name", minionName);
            insertMinion.Parameters.AddWithValue("@age", minionAge);
            insertMinion.Parameters.AddWithValue("@townId", townId);
            insertMinion.ExecuteNonQuery();
            Console.WriteLine($"Successfully added {minionName} to be minion of {vilainName}.");

            var commandMinion = new SqlCommand(Command.searchMinionByName, connection);
            commandMinion.Parameters.AddWithValue("@Name", minionName);
            var idMinion = (int)commandMinion.ExecuteScalar();
            var vilainId = (int)commandVilain.ExecuteScalar();

            var insertVilainMinion = new SqlCommand(Command.insertMinionsVillains, connection);
            insertVilainMinion.Parameters.AddWithValue("@minionId", idMinion);
            insertVilainMinion.Parameters.AddWithValue("@villainId", vilainId);
            insertVilainMinion.ExecuteNonQuery();

        }
    }
}
