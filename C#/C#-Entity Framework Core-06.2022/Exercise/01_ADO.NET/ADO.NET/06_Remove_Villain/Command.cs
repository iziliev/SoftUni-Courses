namespace _06_Remove_Villain
{
    public static class Command
    {
        public static string searchVilainById = @"SELECT [Name] FROM [Villains] WHERE [Id] = @villainId";

        public static string deleteMinionVilainByVilainId= @"DELETE FROM [MinionsVillains] WHERE [VillainId] = @villainId";

        public static string deleteVilainById = @"DELETE FROM [Villains] WHERE [Id] = @villainId";
    }
}
