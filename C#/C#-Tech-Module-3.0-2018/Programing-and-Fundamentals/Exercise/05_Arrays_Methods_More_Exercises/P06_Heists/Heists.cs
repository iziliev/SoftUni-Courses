using System;
using System.Linq;

namespace P06_Heists
{
    class Heists
    {
        static void Main()
        {
            double[] price = Console.ReadLine()
                .Split(' ')
                .Select(double.Parse)
                .ToArray();

            double priceJewels = price[0];
            double priceGold = price[1];
            
            string[] command = Console.ReadLine()
                .Split(' ');

            double totaEarnings = 0;
            double totalExpenses = 0;

            while (command[0] != "Jail" && command[1] != "Time")
            {
                string text = command[0];
                double expensise = double.Parse(command[1]);

                int countGold = 0;
                int countJewels = 0;

                for (int i = 0; i < text.Length; i++)
                {
                    string check = text[i].ToString();
                    if (check == "%")
                    {
                        countJewels++;
                    }
                    if (check == "$")
                    {
                        countGold++;
                    }
                }

                totaEarnings += countGold * priceGold + countJewels * priceJewels;
                totalExpenses += expensise;

                command = Console.ReadLine()
                .Split(' ');
            }
            if (totaEarnings >= totalExpenses)
            {
                Console.WriteLine($"Heists will continue. Total earnings: {totaEarnings-totalExpenses}.");
            }
            else
            {
                Console.WriteLine($"Have to find another job. Lost: {totalExpenses-totaEarnings}.");
            }
        }
    }
}
