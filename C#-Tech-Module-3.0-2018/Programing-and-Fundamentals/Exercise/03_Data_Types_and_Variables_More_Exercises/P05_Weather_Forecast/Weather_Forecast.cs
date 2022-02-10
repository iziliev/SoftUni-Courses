namespace P05_Weather_Forecast
{
    using System;
    class Weather_Forecast
    {
        static void Main()
        {
            string input = Console.ReadLine();

            try
            {
                long num = long.Parse(input);

                if (sbyte.MinValue <= num && sbyte.MaxValue >= num)
                {
                    Console.WriteLine("Sunny");
                }
                else if (int.MinValue <= num && int.MaxValue >= num)
                {
                    Console.WriteLine("Cloudy");
                }
                else if (long.MinValue <= num && long.MaxValue >= num)
                {
                    Console.WriteLine("Windy");
                }
            }
            catch (Exception)
            {
                double n = double.Parse(input);
                Console.WriteLine("Rainy");
            }
        }
    }
}
