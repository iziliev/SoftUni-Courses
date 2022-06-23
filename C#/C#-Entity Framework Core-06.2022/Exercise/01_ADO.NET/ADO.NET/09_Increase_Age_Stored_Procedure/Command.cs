namespace _09_Increase_Age_Stored_Procedure
{
    public static class Command
    {
        public static string createProcedure = @"CREATE PROC usp_GetOlder @id INT
                                                AS
                                                UPDATE [Minions]
                                                   SET [Age] += 1
                                                 WHERE [Id] = @id";

        public static string selectMinion = @"SELECT [Name], [Age] FROM [Minions] WHERE [Id] = @Id";

        public static string execProcedure = @"EXEC usp_GetOlder @Id";

        public static string existProcedure = @"SELECT * FROM SYS.PROCEDURES";
    }
}
