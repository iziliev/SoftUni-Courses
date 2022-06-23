namespace _04_Add_Minion
{
    public static class Command
    {
        public static string searchTownById = @"SELECT [Id] FROM [Towns] WHERE [Name] = @townName";

        public static string insertTown = @"INSERT INTO [Towns] ([Name]) VALUES (@townName)";

        public static string searchVilainsByName = @"SELECT [Id] FROM [Villains] WHERE [Name] = @Name";

        public static string insertVilains = @"INSERT INTO [Villains] ([Name], [EvilnessFactorId])  VALUES (@villainName, 4)";

        public static string searchMinionByName = @"SELECT [Id] FROM [Minions] WHERE [Name] = @Name";

        public static string insertMinion = @"INSERT INTO [Minions] ([Name], [Age], [TownId]) VALUES (@name, @age, @townId)";

        public static string insertMinionsVillains = @"INSERT INTO [MinionsVillains] ([MinionId], [VillainId]) VALUES (@minionId, @villainId)";
    }
}
