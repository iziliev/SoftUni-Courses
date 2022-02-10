using System;
using System.Linq;

namespace P05_Magic_Exchangeable_Words
{
    class Magic_Exchangeable_Words
    {
        static void Main()
        {
            string[] input = Console.ReadLine()
                .Split();

            var wordOne = input[0].Distinct().Count();
            var wordTwo = input[1].Distinct().Count();

            if (wordOne == wordTwo)
            {
                Console.WriteLine("true");
            }
            else
            {
                Console.WriteLine("false");
            }

        }
    }
}
