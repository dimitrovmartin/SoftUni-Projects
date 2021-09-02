using P03_FootballBetting.Data;
using System;

namespace P03_FootballBetting
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            FootballBettingContext context = new FootballBettingContext();

            context.Database.EnsureDeleted();
            context.Database.EnsureCreated();
        }
    }
}
