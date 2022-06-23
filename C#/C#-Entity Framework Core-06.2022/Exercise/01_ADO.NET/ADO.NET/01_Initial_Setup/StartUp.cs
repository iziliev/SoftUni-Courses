using Microsoft.Data.SqlClient;

namespace _01_Initial_Setup
{
    public class StartUp
    {
        public static void Main()
        {
            using var connection = new SqlConnection(Config.connectionStr);

            connection.Open();

            //Create new Database - use 

            var commandCreateDB = new SqlCommand(Command.createDB,connection);
            commandCreateDB.ExecuteNonQuery();
            
            //Create Tables in database
            
            var commandCreateTable = new SqlCommand(Command.cteateTable, connection);
            commandCreateTable.ExecuteNonQuery();

            //Insert Values in Database

            var commandInsertValuesInTable = new SqlCommand(Command.insertValues, connection);
            commandInsertValuesInTable.ExecuteNonQuery();
            
            connection.Close();
        }
    }
}
