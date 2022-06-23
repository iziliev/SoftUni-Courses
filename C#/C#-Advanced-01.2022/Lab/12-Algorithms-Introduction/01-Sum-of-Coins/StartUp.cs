using System;
using System.Collections.Generic;
using System.Linq;

namespace Sum_of_Coins
{
    public class StartUp
    {
        public static void Main()
        {
            var coins = Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray()
                .OrderBy(x => x).ToList();

            var target = int.Parse(Console.ReadLine());

            try
            {
                var dict = ChooseCoins(coins, target);

                Console.WriteLine($"Number of coins to take: {dict.Sum(x => x.Value)}");

                foreach (var coin in dict)
                {
                    Console.WriteLine($"{coin.Value} coin(s) with value {coin.Key}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public static Dictionary<int, int> ChooseCoins(IList<int> coins, int targetSum)
        {
            var coinDict = new Dictionary<int, int>();
            var index = coins.Count - 1;

            while (index >= 0)
            {
                var resultSum = targetSum / coins[index];
                if (resultSum >= 1)
                {
                    coinDict.Add(coins[index], resultSum);
                    targetSum -= resultSum * coins[index];
                }
                else
                {
                    index--;
                }
                if (targetSum == 0)
                {
                    return coinDict;
                }
            }
            throw new InvalidOperationException("Error");
        }
    }
}
