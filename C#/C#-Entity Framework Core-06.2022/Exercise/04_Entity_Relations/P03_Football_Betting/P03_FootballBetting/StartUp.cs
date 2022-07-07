using Microsoft.EntityFrameworkCore;
using P03_FootballBetting.Data;
using System;

namespace P03_FootballBetting
{
    public class StartUp
    {
        public static void Main()
        {
            var context = new FootballBettingContext();

            context.Database.Migrate();
        }
    }
}
