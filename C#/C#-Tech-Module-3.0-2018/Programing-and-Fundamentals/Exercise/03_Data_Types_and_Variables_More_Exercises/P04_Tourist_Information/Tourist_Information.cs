namespace P04_Tourist_Information
{
    using System;
    class Tourist_Information
    {
        static void Main()
        {
            string input = Console.ReadLine();
            double nums = double.Parse(Console.ReadLine());

            switch (input)
            {
                case "miles":
                    Console.WriteLine($"{nums} {input} = {(nums*1.6):F2} kilometers");
                    break;
                case "inches":
                    Console.WriteLine($"{nums} {input} = {(nums * 2.54):F2} centimeters");
                    break;
                case "feet":
                    Console.WriteLine($"{nums} {input} = {(nums * 30):F2} centimeters");
                    break;
                case "yards":
                    Console.WriteLine($"{nums} {input} = {(nums * 0.91):F2} meters");
                    break;
                case "gallons":
                    Console.WriteLine($"{nums} {input} = {(nums * 3.8):F2} liters");
                    break;
            }
        }
    }
}
