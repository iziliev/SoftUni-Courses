using System;
using System.Collections.Generic;
using System.Linq;

namespace P05_Hands_of_Cards
{
    class Hands_of_Cards
    {
        static void Main()
        {
            string input = Console.ReadLine();

            Dictionary<string, HashSet<string>> cards = new Dictionary<string, HashSet<string>>();

            while (input != "JOKER")
            {
                var inputs = input.Split(':');
                var name = inputs[0];
                var card = inputs[1]
                    .Trim()
                    .Split(", ".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);

                if (!cards.ContainsKey(name))
                {
                    cards.Add(name, new HashSet<string>());
                }
                for (int i = 0; i < card.Length; i++)
                {
                    cards[name].Add(card[i]);
                }

                input = Console.ReadLine();
            }

            foreach (var item in cards)
            {
                string namePlayer = item.Key;

                int sum = 0;
                int first = 0;
                int second = 0;
                
                List<string> playerCards = item.Value.ToList();
                                
                for (int i = 0; i < playerCards.Count; i++)
                {
                    int lenght = playerCards[i].Length;

                    if (playerCards[i].Contains("2"))
                    {
                        first = 2;
                    }
                    else if (playerCards[i].Contains("3"))
                    {
                        first = 3;
                    }
                    else if (playerCards[i].Contains("4"))
                    {
                        first = 4;
                    }
                    else if (playerCards[i].Contains("5"))
                    {
                        first = 5;
                    }
                    else if (playerCards[i].Contains("6"))
                    {
                        first = 6;
                    }
                    else if (playerCards[i].Contains("7"))
                    {
                        first = 7;
                    }
                    else if (playerCards[i].Contains("8"))
                    {
                        first = 8;
                    }
                    else if (playerCards[i].Contains("9"))
                    {
                        first = 9;
                    }
                    else if (playerCards[i].Contains("10"))
                    {
                        first = 10;
                    }
                    else if (playerCards[i].Contains("J"))
                    {
                        first = 11;
                    }
                    else if (playerCards[i].Contains("Q"))
                    {
                        first = 12;
                    }
                    else if (playerCards[i].Contains("K"))
                    {
                        first = 13;
                    }
                    else if (playerCards[i].Contains("A"))
                    {
                        first = 14;
                    }

                    if (playerCards[i].Contains("S"))
                    {
                        second = 4;
                    }
                    else if (playerCards[i].Contains("H"))
                    {
                        second = 3;
                    }
                    else if(playerCards[i].Contains("D"))
                    {
                        second = 2;
                    }
                    else if(playerCards[i].Contains("C"))
                    {
                        second = 1;
                    }
                    sum += first * second;
                }
                Console.WriteLine($"{item.Key}: {sum}");
            }
        }
    }
}
