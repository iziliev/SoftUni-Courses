namespace P04_Hotel
{
    using System;
    class Hotel
    {
        static void Main()
        {
            string month = Console.ReadLine().ToLower();
            int nights = int.Parse(Console.ReadLine());

            decimal priceStudio = 0M;
            decimal priceDouble = 0M;
            decimal priceSuite = 0M;

            switch (month)
            {
                case "may":
                    if (nights <= 7)
                    {
                        priceStudio = nights * 50;
                        priceDouble = nights * 65;
                        priceSuite = nights * 75;
                    }
                    else
                    {
                        priceStudio = nights * 50 * 0.95M;
                        priceDouble = nights * 65;
                        priceSuite = nights * 75;
                    }
                    break;
                case "october":
                    if (nights <= 7)
                    {
                        priceStudio = nights * 50;
                        priceDouble = nights * 65;
                        priceSuite = nights * 75;
                    }
                    else
                    {
                        priceStudio = (nights - 1) * 50 * 0.95M;
                        priceDouble = nights * 65;
                        priceSuite = nights * 75;
                    }
                    break;
                case "june":
                    if (nights <= 14)
                    {
                        priceStudio = nights * 60;
                        priceDouble = nights * 72;
                        priceSuite = nights * 82;
                    }
                    else
                    {
                        priceStudio = nights * 60;
                        priceDouble = nights * 72 * 0.90M;
                        priceSuite = nights * 82;
                    }
                    break;
                case "september":
                    if (nights <= 7)
                    {
                        priceStudio = nights * 60;
                        priceDouble = nights * 72;
                        priceSuite = nights * 82;
                    }
                    else if (nights > 7 && nights <= 14)
                    {
                        priceStudio = (nights - 1) * 60;
                        priceDouble = nights * 72;
                        priceSuite = nights * 82;
                    }
                    else
                    {
                        priceStudio = nights * 60;
                        priceDouble = nights * 72 * 0.90M;
                        priceSuite = nights * 82;
                    }
                    break;
                case "july":
                case "august":
                case "december":
                    if (nights <= 14)
                    {
                        priceStudio = nights * 68;
                        priceDouble = nights * 77;
                        priceSuite = nights * 89;
                    }
                    else
                    {
                        priceStudio = nights * 68;
                        priceDouble = nights * 77;
                        priceSuite = nights * 89 * 0.85M;
                    }
                    break;
            }
            Console.WriteLine($"Studio: {priceStudio:F2} lv.");
            Console.WriteLine($"Double: {priceDouble:F2} lv.");
            Console.WriteLine($"Suite: {priceSuite:F2} lv.");
        }
    }
}
