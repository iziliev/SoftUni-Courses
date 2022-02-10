namespace P10_Sum_of_Chars
{
    using System;
    class Sum_of_Chars
    {
        static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            int sum = 0;
            for (int i = 0; i < n; i++)
            {
                char letter = char.Parse(Console.ReadLine());
                int number = Convert.ToInt32(letter);
                sum += letter;
            }
            Console.WriteLine($"The sum equals: {sum}");
        }
    }
}
