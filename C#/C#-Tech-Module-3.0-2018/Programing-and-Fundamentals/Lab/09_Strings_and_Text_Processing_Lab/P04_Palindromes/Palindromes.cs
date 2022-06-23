using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace P04_Palindromes
{
    class Palindromes
    {
        static void Main()
        {
            string[] text = Console.ReadLine()
                .Split(" ,.?!".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);

            List<string> palindromes = new List<string>();

            for (int i = 0; i < text.Length; i++)
            {
                string word = text[i];
                StringBuilder sb = new StringBuilder();
                for (int j = word.Length-1; j >= 0; j--)
                {
                    sb.Append(word[j]);
                }
                var revercedWord = sb.ToString();

                var result = string.Compare(word, revercedWord);

                if (result == 0)
                {
                    palindromes.Add(revercedWord);
                }
            }
            Console.WriteLine(string.Join(", ", palindromes.OrderBy(x=>x)));
        }
    }
}
