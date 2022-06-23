namespace _03_Minion_Names
{
    public static class Command
    {
        public static string getVillainNameQuery = @"SELECT [Name] FROM [Villains] WHERE [Id] = @Id";

        public static string getMinionsQuery = @"SELECT ROW_NUMBER() OVER (ORDER BY m.Name) as RowNum,
                                         m.Name, 
                                         m.Age
                                    FROM MinionsVillains AS mv
                                    JOIN Minions As m ON mv.MinionId = m.Id
                                   WHERE mv.VillainId = @Id
                                ORDER BY m.Name";
    }
}
