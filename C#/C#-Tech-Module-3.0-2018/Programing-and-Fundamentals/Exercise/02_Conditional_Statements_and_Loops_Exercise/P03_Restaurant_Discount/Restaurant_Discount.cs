namespace P03_Restaurant_Discount
{
    using System;
    class Restaurant_Discount
    {
        static void Main()
        {
            int groupSize = int.Parse(Console.ReadLine());
            string package = Console.ReadLine();
            decimal price = 0M;
            string hall = string.Empty;

            if (groupSize <= 50)
            {
                if (package == "Normal")
                {
                    price = (2500 + 500) * 0.95M;
                    hall = "Small Hall";
                }
                else if (package == "Gold")
                {
                    price = (2500 + 750) * 0.90M;
                    hall = "Small Hall";
                }
                else if (package == "Platinum")
                {
                    price = (2500 + 1000) * 0.85M;
                    hall = "Small Hall";
                }
            }
            else if (groupSize > 50 && groupSize <= 100)
            {
                if (package == "Normal")
                {
                    price = (5000 + 500) * 0.95M;
                    hall = "Terrace";
                }
                else if (package == "Gold")
                {
                    price = (5000 + 750) * 0.90M;
                    hall = "Terrace";
                }
                else if (package == "Platinum")
                {
                    price = (5000 + 1000) * 0.85M;
                    hall = "Terrace";
                }
            }
            else if (groupSize > 100 && groupSize <= 120)
            {
                if (package == "Normal")
                {
                    price = (7500 + 500) * 0.95M;
                    hall = "Great Hall";
                }
                else if (package == "Gold")
                {
                    price = (7500 + 750) * 0.90M;
                    hall = "Great Hall";
                }
                else if (package == "Platinum")
                {
                    price = (7500 + 1000) * 0.85M;
                    hall = "Great Hall";
                }
            }
            else
            {
                Console.WriteLine("We do not have an appropriate hall.");
                return;
            }
            decimal pricePerPerson = price / groupSize;
            Console.WriteLine($"We can offer you the {hall}");
            Console.WriteLine($"The price per person is {pricePerPerson:F2}$");
        }
    }
}
