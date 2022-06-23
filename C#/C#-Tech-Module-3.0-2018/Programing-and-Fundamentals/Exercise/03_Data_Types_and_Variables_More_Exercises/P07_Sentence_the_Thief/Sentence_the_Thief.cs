namespace P07_Sentence_the_Thief
{
    using System;
    class Sentence_the_Thief
    {
        static void Main()
        {
            string input = Console.ReadLine();
            int n = int.Parse(Console.ReadLine());
            var maxNum = double.MinValue;
            for (int i = 0; i < n; i++)
            {
                long num = long.Parse(Console.ReadLine());

                if (input == "sbyte" &&
                    num >= sbyte.MinValue &&
                    num <= sbyte.MaxValue)
                {
                    if (maxNum < num)
                    {
                        maxNum = num;
                    }
                }
                if (input == "int" &&
                    num >= int.MinValue &&
                    num <= int.MaxValue)
                {
                    if (maxNum < num)
                    {
                        maxNum = num;
                    }
                }
                if (input == "long" &&
                    num >= long.MinValue &&
                    num <= long.MaxValue)
                {
                    if (maxNum < num)
                    {
                        maxNum = num;
                    }
                }
            }
            double years = double.MinValue;
            if (maxNum < 0)
            {
                sbyte min = sbyte.MinValue;
                years = Math.Ceiling((double)(maxNum / min));
                if (years > 1)
                {
                    Console.WriteLine($"Prisoner with id {maxNum} is sentenced to {years} years");
                }
                else
                {
                    Console.WriteLine($"Prisoner with id {maxNum} is sentenced to {years} year");
                }
            }
            else
            {
                sbyte min = sbyte.MaxValue;
                years = Math.Ceiling((double)(maxNum / min));
                if (years > 1)
                {
                    Console.WriteLine($"Prisoner with id {maxNum} is sentenced to {years} years");
                }
                else
                {
                    Console.WriteLine($"Prisoner with id {maxNum} is sentenced to {years} year");
                }
            }
        }
    }
}
