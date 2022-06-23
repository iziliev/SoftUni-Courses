using System;
using System.Collections.Generic;
using System.Linq;

namespace _03_Cards
{
    public class StartUp
    {
        public static void Main()
        {
            var cards = new List<ICard>();

            var input = Console.ReadLine()
                .Split(", ", StringSplitOptions.RemoveEmptyEntries);

            for (int i = 0; i < input.Length; i++)
            {
                var cardArgs = input[i].Split();

                try
                {
                    cards.Add(new Card(cardArgs[0], cardArgs[1]));
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }

            Console.WriteLine(String.Join(" ", cards));
        }

    }
}
