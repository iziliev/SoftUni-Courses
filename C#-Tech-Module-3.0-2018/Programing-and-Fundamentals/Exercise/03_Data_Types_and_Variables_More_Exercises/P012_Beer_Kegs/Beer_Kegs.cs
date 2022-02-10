using System;

namespace P012_Beer_Kegs
{
    class Beer_Kegs
    {
        static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            double maxResult = 0.00;
            string keg = string.Empty;
            for (int i = 0; i < n; i++)
            {
                string model = Console.ReadLine();
                double radius = double.Parse(Console.ReadLine());
                double height = double.Parse(Console.ReadLine());

                double result = Math.PI * radius * radius * height;

                if (maxResult<result)
                {
                    maxResult = result;
                    keg = model;
                }
            }
            Console.WriteLine(keg);
        }
    }
}
