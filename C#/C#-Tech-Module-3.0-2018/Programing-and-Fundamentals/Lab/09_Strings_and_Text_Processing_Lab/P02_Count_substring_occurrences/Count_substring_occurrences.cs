using System;

namespace P02_Count_Substring_Occurrences
{
    class Count_Substring_Occurrences
    {
        static void Main()
        {
            string text = Console.ReadLine().ToLower();

            string pattern = Console.ReadLine().ToLower();

            int index = 0;
            int count = 0;

            while (index != -1)
            {
                count++;
                index = text.IndexOf(pattern, index + 1);
            }
            Console.WriteLine(count);
        }
    }
}
