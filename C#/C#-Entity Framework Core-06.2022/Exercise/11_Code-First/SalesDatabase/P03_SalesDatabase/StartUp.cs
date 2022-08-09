using P03_SalesDatabase.Data;
using System;

namespace P03_SalesDatabase
{
    public class StartUp
    {
        public static void Main()
        {
            var context = new SalesContext();
            context.Database.EnsureDeleted();
            context.Database.EnsureCreated();
        }
    }
}
