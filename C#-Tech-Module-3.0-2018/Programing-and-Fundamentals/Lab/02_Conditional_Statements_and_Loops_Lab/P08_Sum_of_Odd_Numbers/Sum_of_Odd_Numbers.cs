namespace P08_Sum_of_Odd_Numbers
{
    using System;
    class Sum_of_Odd_Numbers
    {
        static void Main()
        {
            int number = int.Parse(Console.ReadLine());
            int sum = 0;
           
            for (int i = 1; i <= number; i++)
            {    
                Console.WriteLine(i*2-1);
                sum += i*2-1;
            }
            Console.WriteLine($"Sum: {sum}");
        }
    }
}
