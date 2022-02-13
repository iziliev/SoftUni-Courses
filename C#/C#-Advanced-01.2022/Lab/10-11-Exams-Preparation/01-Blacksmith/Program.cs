using System;
using System.Collections.Generic;
using System.Linq;

namespace Blacksmith
{
    public class Program
    {
        public static int[] swords = new int[] { 70, 80, 90, 110, 150 };
        public static void Main()
        {
            var steel = new Queue<int>(Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse));

            var carbon = new Stack<int>(Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse));

            var sword = new Dictionary<string, int>()
            {
                {"Gladius",0 },
                {"Shamshir",0 },
                {"Katana",0 },
                {"Sabre",0 },
                {"Broadsword",0 }
            };

            while (steel.Count > 0 && carbon.Count > 0)
            {
                var currentSteel = steel.Dequeue();
                var currentCarbon = carbon.Peek();

                var index = Array.IndexOf(swords, currentCarbon + currentSteel);

                switch (index)
                {
                    case -1:
                        carbon.Push(carbon.Pop() + 5);
                        break;
                    case 0:
                        carbon.Pop();
                        sword["Gladius"]++;
                        break;
                    case 1:
                        carbon.Pop();
                        sword["Shamshir"]++;
                        break;
                    case 2:
                        carbon.Pop();
                        sword["Katana"]++;
                        break;
                    case 3:
                        carbon.Pop();
                        sword["Sabre"]++;
                        break;
                    case 4:
                        carbon.Pop();
                        sword["Broadsword"]++;
                        break;
                    default:
                        break;
                }
            }

            if (!sword.Any(x=>x.Value>0))
            {
                Console.WriteLine("You did not have enough resources to forge a sword.");
            }
            else
            {
                Console.WriteLine($"You have forged {sword.Values.Sum()} swords.");
            }

            if (steel.Count==0)
            {
                Console.WriteLine("Steel left: none");
            }
            else
            {
                Console.WriteLine($"Steel left: {string.Join(", ",steel)}");
            }

            if (carbon.Count == 0)
            {
                Console.WriteLine("Carbon left: none");
            }
            else
            {
                Console.WriteLine($"Carbon left: {string.Join(", ", carbon)}");
            }

            foreach (var item in sword.Where(x=>x.Value>0).OrderBy(x=>x.Key))
            {
                Console.WriteLine($"{item.Key}: {item.Value}");
            }
        }
    }
}
