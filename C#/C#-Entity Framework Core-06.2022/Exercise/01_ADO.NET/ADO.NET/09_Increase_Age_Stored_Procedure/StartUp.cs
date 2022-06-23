using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _09_Increase_Age_Stored_Procedure
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

            var procedureList = new List<string>();
            var existProcedure = new SqlCommand(Command.existProcedure, connection);
            using var readerProc = existProcedure.ExecuteReader();

            while (readerProc.Read())
            {
                procedureList.Add((string)readerProc["name"]);
            }

            readerProc.Close();

            if (!procedureList.Contains("usp_GetOlder"))
            {
                var create = new SqlCommand(Command.createProcedure, connection);
                create.ExecuteNonQuery();
            }

            var sb = new StringBuilder();

            for (int i = 0; i < ids.Length; i++)
            {
                var command = new SqlCommand(Command.execProcedure, connection);
                command.Parameters.AddWithValue("@Id", ids[i]);
                command.ExecuteNonQuery();

                var selectMinion = new SqlCommand(Command.selectMinion, connection);
                selectMinion.Parameters.AddWithValue("@Id", ids[i]);
                using var reader = selectMinion.ExecuteReader();

                while (reader.Read())
                {
                    Console.WriteLine(@$"{(string)reader["Name"]} – {(int)reader["Age"]} years old");
                }

                reader.Close();
            }

            connection.Close();
        }
    }
}
