using System;
using System.Collections.Generic;

namespace P04_Split_by_Word_Casing
{
    class Split_by_Word_Casing
    {
        static void Main()
        {
            string[] array = Console.ReadLine()
                .Split(",;:. !( ) \"\'\\/[] ".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);

            List<string> lowerCase = new List<string>();
            List<string> mixedCase = new List<string>();
            List<string> upperCase = new List<string>();
            
            for (int i = 0; i < array.Length; i++)
            {
                string word = array[i];
                int countLower = 0;
                int countMixed = 0;
                int countUpper = 0;
                for (int j = 0; j < word.Length; j++)
                {
                    char letter = word[j];
                    if (char.IsLower(letter))
                    {
                        countLower++;
                    }
                    else if (char.IsUpper(letter))
                    {
                        countUpper++;
                    }
                    else
                    {
                        countMixed++;
                    }
                }
                if (countLower == word.Length)
                {
                    lowerCase.Add(word);
                }
                else if (countUpper == word.Length)
                {
                    upperCase.Add(word);
                }
                else
                {
                    mixedCase.Add(word);
                }
            }
            Console.WriteLine($"Lower-case: {string.Join(", ",lowerCase)}");
            Console.WriteLine($"Mixed-case: {string.Join(", ", mixedCase)}");
            Console.WriteLine($"Upper-case: {string.Join(", ", upperCase)}");
        }
    }
}
