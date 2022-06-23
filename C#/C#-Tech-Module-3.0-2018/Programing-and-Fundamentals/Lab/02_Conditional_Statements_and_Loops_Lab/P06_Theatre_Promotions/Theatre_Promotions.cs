namespace P06_Theatre_Promotions
{
    using System;
    class Theatre_Promotions
    {
        static void Main()
        {
            string day = Console.ReadLine().ToLower();
            int age = int.Parse(Console.ReadLine());

            switch (day)
            {
                case "weekday":
                    if (age >= 0 && age <= 18)
                    {
                        Console.WriteLine("12$");
                    }
                    else if (age > 18 && age <= 64)
                    {
                        Console.WriteLine("18$");
                    }
                    else if (age > 64 && age <= 122)
                    {
                        Console.WriteLine("12$");
                    }
                    else
                    {
                        Console.WriteLine("Error!");
                    }
                    break;
                case "weekend":
                    if (age >= 0 && age <= 18)
                    {
                        Console.WriteLine("15$");
                    }
                    else if (age > 18 && age <= 64)
                    {
                        Console.WriteLine("20$");
                    }
                    else if (age > 64 && age <= 122)
                    {
                        Console.WriteLine("15$");
                    }
                    else
                    {
                        Console.WriteLine("Error!");
                    }
                    break;
                case "holiday":
                    if (age >= 0 && age <= 18)
                    {
                        Console.WriteLine("5$");
                    }
                    else if (age > 18 && age <= 64)
                    {
                        Console.WriteLine("12$");
                    }
                    else if (age > 64 && age <= 122)
                    {
                        Console.WriteLine("10$");
                    }
                    else
                    {
                        Console.WriteLine("Error!");
                    }
                    break;
                default:
                    Console.WriteLine("Error!");
                    break;
            }
        }
    }
}
