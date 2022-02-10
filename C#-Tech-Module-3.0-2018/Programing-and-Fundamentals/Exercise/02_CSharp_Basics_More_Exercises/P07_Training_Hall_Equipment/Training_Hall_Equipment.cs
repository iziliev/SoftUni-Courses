namespace P07_Training_Hall_Equipment
{
    using System;
    class Training_Hall_Equipment
    {
        static void Main(string[] args)
        {
            decimal budjet = decimal.Parse(Console.ReadLine());
            int n = int.Parse(Console.ReadLine());
            decimal sum = 0M;

            for (int i = 0; i < n; i++)
            {
                string itemName = Console.ReadLine();
                decimal priceItem = decimal.Parse(Console.ReadLine());
                int itemCount = int.Parse(Console.ReadLine());

                sum += priceItem * itemCount;

                if (itemCount>1)
                {
                    Console.WriteLine($"Adding {itemCount} {itemName}s to cart.");
                }
                else
                {
                    Console.WriteLine($"Adding {itemCount} {itemName} to cart.");
                }
            }

            Console.WriteLine($"Subtotal: ${sum:F2}");
            if (sum <= budjet)
            {
                Console.WriteLine($"Money left: ${(budjet-sum):F2}");
            }
            else
            {
                Console.WriteLine($"Not enough. We need ${(sum-budjet):F2} more.");
            }
        }
    }
}
