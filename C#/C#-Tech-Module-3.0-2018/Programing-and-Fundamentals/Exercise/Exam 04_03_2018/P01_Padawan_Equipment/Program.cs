using System;

namespace P01_Padawan_Equipment
{
    class Program
    {
        static void Main(string[] args)
        {
            decimal amountIvanchou = decimal.Parse(Console.ReadLine());
            int countStudents = int.Parse(Console.ReadLine());
            decimal priceLightSabers = decimal.Parse(Console.ReadLine());
            decimal priceRobes = decimal.Parse(Console.ReadLine());
            decimal priceBelts = decimal.Parse(Console.ReadLine());

            int countFinal = (int)Math.Ceiling(countStudents * 1.1);
            int countBelt = countStudents / 6; ;

            decimal sum = priceLightSabers * (countFinal) + priceRobes*countStudents + (priceBelts * (countStudents-countBelt));

            if (sum<=amountIvanchou)
            {
                Console.WriteLine($"The money is enough - it would cost {sum:F2}lv.");
            }
            else
            {
                Console.WriteLine($"Ivan Cho will need {sum-amountIvanchou:F2}lv more.");
            }
        }
    }
}
