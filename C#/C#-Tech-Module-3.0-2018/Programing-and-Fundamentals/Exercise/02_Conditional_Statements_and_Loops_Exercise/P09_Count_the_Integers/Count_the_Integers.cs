namespace P09_Count_the_Integers
{
    using System;
    class Count_the_Integers
    {
        static void Main()
        {
            string input = Console.ReadLine();
            int count = 0;

            while (true)
            {
                try
                {
                    int num = int.Parse(input);
                    count++;
                }
                catch (Exception)
                {
                    Console.WriteLine(count);
                    break;
                }
                input = Console.ReadLine();
            }
        }
    }
}
