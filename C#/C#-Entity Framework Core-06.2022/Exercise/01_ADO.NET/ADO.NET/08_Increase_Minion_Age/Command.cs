namespace _08_Increase_Minion_Age
{
    public static class Command
    {
        public static string increaseAgeOnMinion = @"UPDATE [Minions]
                                                        SET [Name] = UPPER(LEFT([Name], 1)) + SUBSTRING([Name], 2, LEN([Name])), [Age] += 1
                                                        WHERE [Id] = @Id";

        public static string selectMinion = @"SELECT [Name], [Age] FROM [Minions]";
    }
}
