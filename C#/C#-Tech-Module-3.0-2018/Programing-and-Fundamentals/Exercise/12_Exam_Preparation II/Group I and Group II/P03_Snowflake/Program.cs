using System;
using System.Text.RegularExpressions;

namespace P03_Snowflake
{
    class Program
    {
        static void Main(string[] args)
        {
            string surface = Console.ReadLine();
            string mantle = Console.ReadLine();
            string core = Console.ReadLine();
            string secondMantle = Console.ReadLine();
            string secondSurface = Console.ReadLine();

            string surfacePattern = @"[^A-Za-z0-9]+";
            string mantlePattern = @"[0-9_]+";
            string corePattern = $@"{surfacePattern}{mantlePattern}([A-Za-z]+){mantlePattern}{surfacePattern}";


            var surfaceRegex = new Regex($"^{surfacePattern}$");
            var matchSurface = surfaceRegex.Match(surface).ToString();

            if (matchSurface != surface)
            {
                Console.WriteLine("Invalid");
                return;
            }
            var mantleRegex = new Regex($"^{mantlePattern}$");
            var matchMantle = mantleRegex.Match(mantle).ToString();

            if (matchMantle != mantle)
            {
                Console.WriteLine("Invalid");
                return;
            }

            var coreRegex = new Regex($"^{corePattern}$");
            var matchCore = coreRegex.Match(core).ToString();

            if (matchCore != core)
            {
                Console.WriteLine("Invalid");
                return;
            }

            var secondMantleRegex = new Regex($"^{mantlePattern}$");
            var matchSecondMantle = secondMantleRegex.Match(secondMantle).ToString();

            if (matchSecondMantle != secondMantle)
            {
                Console.WriteLine("Invalid");
                return;
            }

            var secondSurfaceRegex = new Regex($"^{surfacePattern}$");
            var matchSecondSurface = secondSurfaceRegex.Match(secondSurface).ToString();

            if (matchSecondSurface != secondSurface)
            {
                Console.WriteLine("Invalid");
                return;
            }


            Console.WriteLine("Valid");

            var match = coreRegex.Match(core);

            Console.WriteLine(match.Groups[1].Length);
        }
    }
}
