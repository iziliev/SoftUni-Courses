using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ADO.Net
{
    public class StartUp
    {
        public static void Main()
        {
            using var connection = new SqlConnection(Config.connectionStr);
            connection.Open();
            
            //Problem_01_Initial_Setup
            InitialSetup(connection);

            //Problem_02_Villain_Names
            VillainNames(connection);

            //Problem_03_Minion_Names
            MinionNames(connection);

            //Problem_04_Add_Minion
            AddMinion(connection);

            //Problem_05_Change_Town_Names
            ChangeTownNames(connection);

            //Problem_06_Remove_Villain
            RemoveVillain(connection);

            //Problem_07_Print_All_Minion_Names
            PrintAllMinionNames(connection);

            //Problem_08_Increase_Minion_Age
            IncreaseMinionAge(connection);

            //Problem_09_Increase_Age_Stored_Procedure
            IncreaseAgeStoredProcedure(connection);

            connection.Close();
        }

        //Problem_01_Initial_Setup
        private static void InitialSetup(SqlConnection connection)
        {
            //Create new Database - use 
            var commandCreateDB = new SqlCommand(Commands.createDB, connection);
            commandCreateDB.ExecuteNonQuery();

            //Create Tables in database
            var commandCreateTable = new SqlCommand(Commands.cteateTable, connection);
            commandCreateTable.ExecuteNonQuery();

            //Insert Values in Database
            var commandInsertValuesInTable = new SqlCommand(Commands.insertValues, connection);
            commandInsertValuesInTable.ExecuteNonQuery();
        }

        //Problem_02_Villain_Names
        private static void VillainNames(SqlConnection connection)
        {
            var command = new SqlCommand(Commands.query, connection);

            using var reader = command.ExecuteReader();

            while (reader.Read())
            {
                Console.WriteLine($"{reader["Name"]} - {reader["MinionsCount"]}");
            }

            reader.Close();
        }

        //Problem_03_Minion_Names
        private static void MinionNames(SqlConnection connection)
        {
            var vilainId = int.Parse(Console.ReadLine());

            var cmdVilainName = new SqlCommand(Commands.getVillainNameQuery, connection);
            cmdVilainName.Parameters.AddWithValue("@Id", vilainId);
            var vilainName = (string)cmdVilainName.ExecuteScalar();

            if (vilainName == null)
            {
                Console.WriteLine($"No villain with ID {vilainId} exists in the database.");
            }
            else
            {
                var cmdMinionsName = new SqlCommand(Commands.getMinionsQuery, connection);
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
        }

        //Problem_04_Add_Minion
        private static void AddMinion(SqlConnection connection)
        {
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
        }

        private static void InsertMinionInDB(SqlConnection connection, string minionName, int minionAge, string minionTown, string vilainName)
        {
            var commandTown = new SqlCommand(Commands.searchTownById, connection);
            commandTown.Parameters.AddWithValue("@townName", minionTown);
            var townId = commandTown.ExecuteScalar();

            if (townId == null)
            {
                var insertTown = new SqlCommand(Commands.insertTown, connection);
                insertTown.Parameters.AddWithValue("@townName", minionTown);
                insertTown.ExecuteNonQuery();
                Console.WriteLine($"Town {minionTown} was added to the database.");
            }

            var commandVilain = new SqlCommand(Commands.searchVilainsByName, connection);
            commandVilain.Parameters.AddWithValue("@Name", vilainName);
            var idVilain = commandVilain.ExecuteScalar();

            if (idVilain == null)
            {
                var insertVilain = new SqlCommand(Commands.insertVilains, connection);
                insertVilain.Parameters.AddWithValue("@villainName", vilainName);
                insertVilain.ExecuteNonQuery();
                Console.WriteLine($"Villain {vilainName} was added to the database.");
            }

            townId = commandTown.ExecuteScalar();

            var insertMinion = new SqlCommand(Commands.insertMinion, connection);
            insertMinion.Parameters.AddWithValue("@name", minionName);
            insertMinion.Parameters.AddWithValue("@age", minionAge);
            insertMinion.Parameters.AddWithValue("@townId", townId);
            insertMinion.ExecuteNonQuery();
            Console.WriteLine($"Successfully added {minionName} to be minion of {vilainName}.");

            var commandMinion = new SqlCommand(Commands.searchMinionByName, connection);
            commandMinion.Parameters.AddWithValue("@Name", minionName);
            var idMinion = (int)commandMinion.ExecuteScalar();
            var vilainId = (int)commandVilain.ExecuteScalar();

            var insertVilainMinion = new SqlCommand(Commands.insertMinionsVillains, connection);
            insertVilainMinion.Parameters.AddWithValue("@minionId", idMinion);
            insertVilainMinion.Parameters.AddWithValue("@villainId", vilainId);
            insertVilainMinion.ExecuteNonQuery();

        }

        //Problem_05_Change_Town_Names
        private static void ChangeTownNames(SqlConnection connection)
        {
            var country = Console.ReadLine();

            var allTownsByCountry = new SqlCommand(Commands.searchCountryByName, connection);
            allTownsByCountry.Parameters.AddWithValue("@countryName", country);

            var countTownsByCountry = allTownsByCountry.ExecuteScalar();

            if (countTownsByCountry == null)
            {
                Console.WriteLine("No town names were affected.");
            }
            else
            {
                var upperCommand = new SqlCommand(Commands.updateNameTawns, connection);
                upperCommand.Parameters.AddWithValue("@countryName", country);
                upperCommand.ExecuteNonQuery();

                var countAffectedTown = 0;
                var listOfTowns = new List<string>();

                using var readerTown = new SqlCommand(Commands.searchCountryByName, connection);
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
        }

        //Problem_06_Remove_Villain
        private static void RemoveVillain(SqlConnection connection)
        {
            var id = int.Parse(Console.ReadLine());
            var searchVilain = new SqlCommand(Commands.searchVilainById, connection);
            searchVilain.Parameters.AddWithValue("@villainId", id);
            var foundVilainName = searchVilain.ExecuteScalar();

            if (foundVilainName == null)
            {
                Console.WriteLine("No such villain was found.");
                return;
            }
            else
            {
                var deleteMinionVilainCommand = new SqlCommand(Commands.deleteMinionVilainByVilainId, connection);
                deleteMinionVilainCommand.Parameters.AddWithValue("@villainId", id);
                var affectedRows = (int)deleteMinionVilainCommand.ExecuteNonQuery();

                var deleteVilain = new SqlCommand(Commands.deleteVilainById, connection);
                deleteVilain.Parameters.AddWithValue("@villainId", id);
                deleteVilain.ExecuteScalar();

                Console.WriteLine($"{foundVilainName} was deleted.");
                Console.WriteLine($"{affectedRows} minions were released.");
            }
        }

        //Problem_07_Print_All_Minion_Names
        private static void PrintAllMinionNames(SqlConnection connection)
        {
            var commandMinion = new SqlCommand(Commands.searchMinionsName, connection);
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
        }

        //Problem_08_Increase_Minion_Age
        private static void IncreaseMinionAge(SqlConnection connection)
        {
            var ids = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            for (int i = 0; i < ids.Length; i++)
            {
                var command = new SqlCommand(Commands.increaseAgeOnMinion, connection);
                command.Parameters.AddWithValue("@Id", ids[i]);
                command.ExecuteNonQuery();
            }

            var showMinion = new SqlCommand(Commands.selectMinion, connection);
            using var reader = showMinion.ExecuteReader();

            while (reader.Read())
            {
                Console.WriteLine($"{reader["Name"]} {reader["Age"]}");
            }

            reader.Close();
        }

        //Problem_09_Increase_Age_Stored_Procedure
        private static void IncreaseAgeStoredProcedure(SqlConnection connection)
        {
            var ids = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();


            var procedureList = new List<string>();
            var existProcedure = new SqlCommand(Commands.existProcedure, connection);
            using var readerProc = existProcedure.ExecuteReader();

            while (readerProc.Read())
            {
                procedureList.Add((string)readerProc["name"]);
            }

            readerProc.Close();

            if (!procedureList.Contains("usp_GetOlder"))
            {
                var create = new SqlCommand(Commands.createProcedure, connection);
                create.ExecuteNonQuery();
            }

            var sb = new StringBuilder();

            for (int i = 0; i < ids.Length; i++)
            {
                var command = new SqlCommand(Commands.execProcedure, connection);
                command.Parameters.AddWithValue("@Id", ids[i]);
                command.ExecuteNonQuery();

                var selectMinion = new SqlCommand(Commands.selectMinionByCondition, connection);
                selectMinion.Parameters.AddWithValue("@Id", ids[i]);
                using var reader = selectMinion.ExecuteReader();

                while (reader.Read())
                {
                    Console.WriteLine(@$"{(string)reader["Name"]} – {(int)reader["Age"]} years old");
                }

                reader.Close();
            }
        }
    }
}
