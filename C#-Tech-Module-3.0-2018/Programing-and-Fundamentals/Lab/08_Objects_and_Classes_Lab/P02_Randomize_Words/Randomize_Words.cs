using System;

namespace P02_Randomize_Words
{
    class Randomize_Words
    {
        static void Main()
        {
            string[] input = Console.ReadLine()
                .Split(' ');

            var random = new Random();

            for (int i = 0; i < input.Length; i++)
            {
                var curentWord = input[i];
                var randomIndex = random.Next(0, input.Length);
                input[i] = input[randomIndex];
                input[randomIndex] = curentWord;
            }
            foreach (var item in input)
            {
                Console.WriteLine(item);
            }
        }
    }
}
