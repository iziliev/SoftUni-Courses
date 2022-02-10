using System;

namespace P02_Max_Method
{
    class Max_Method
    {
        static void Main()
        {
            int numA = int.Parse(Console.ReadLine());
            int numB = int.Parse(Console.ReadLine());
            int numC = int.Parse(Console.ReadLine());
            var result = GetMax(numA,numB,numC);
            Console.WriteLine(result);
        }
        static int GetMax(int numA, int numB, int numC)
        {
            if (numA > numB && numB > numC)
            {
                return numA;
            }
            else if (numA < numB && numA > numC)
            {
                return numB;
            }
            else
            {
                return numC;
            }
        }
    }
}
