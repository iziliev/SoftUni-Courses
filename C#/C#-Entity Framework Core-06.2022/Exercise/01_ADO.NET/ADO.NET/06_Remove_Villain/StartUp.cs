using Microsoft.Data.SqlClient;
using System;

namespace _06_Remove_Villain
{
    public class StartUp
    {
        public static void Main()
        {
            var id = int.Parse(Console.ReadLine());

            using var connection = new SqlConnection(Config.connectionStr);
            connection.Open();

            var searchVilain = new SqlCommand(Command.searchVilainById, connection);
            searchVilain.Parameters.AddWithValue("@villainId", id);
            var foundVilainName = searchVilain.ExecuteScalar();

            if (foundVilainName == null)
            {
                Console.WriteLine("No such villain was found.");
                return;
            }
            else
            {
                var deleteMinionVilainCommand = new SqlCommand(Command.deleteMinionVilainByVilainId, connection);
                deleteMinionVilainCommand.Parameters.AddWithValue("@villainId", id);
                var affectedRows = (int)deleteMinionVilainCommand.ExecuteNonQuery();

                var deleteVilain = new SqlCommand(Command.deleteVilainById, connection);
                deleteVilain.Parameters.AddWithValue("@villainId", id);
                deleteVilain.ExecuteScalar();

                Console.WriteLine($"{foundVilainName} was deleted.");
                Console.WriteLine($"{affectedRows} minions were released.");
            }
            connection.Close();
        }
    }
}
