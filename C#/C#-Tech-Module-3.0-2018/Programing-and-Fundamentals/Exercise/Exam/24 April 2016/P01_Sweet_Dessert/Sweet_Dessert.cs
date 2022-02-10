using System;

namespace P01_Sweet_Dessert
{
    class Sweet_Dessert
    {
        static void Main()
        {
            decimal budgetIvancho = decimal.Parse(Console.ReadLine());
            int guests = int.Parse(Console.ReadLine());
            decimal priceBananas = decimal.Parse(Console.ReadLine());
            decimal priceEggs = decimal.Parse(Console.ReadLine());
            decimal priceBerries = decimal.Parse(Console.ReadLine());

            int portions = (int)(Math.Ceiling((double)guests / 6));

            decimal totalSum = portions * 2 * priceBananas + portions * 4 * priceEggs + portions * (decimal)0.2 * priceBerries;

            if (totalSum <= budgetIvancho)
            {
                Console.WriteLine($"Ivancho has enough money - it would cost {totalSum:F2}lv.");
            }
            else
            {
                Console.WriteLine($"Ivancho will have to withdraw money - he will need {(totalSum-budgetIvancho):F2}lv more.");
            }
        }
    }
}
