using System;
using System.Text;

namespace P05_Only_Letters
{
    class Only_Letters
    {
        static void Main()
        {
            string text = Console.ReadLine();

            StringBuilder sb = new StringBuilder();
            int countDigits = 0;
            for (int i = 0; i < text.Length; i++)
            {
                if (char.IsLetter(text[i]))
                {
                    if (countDigits>0)
                    {
                        sb.Append(text[i]);
                        countDigits = 0;
                    }
                    sb.Append(text[i]);
                }
                else
                {
                    countDigits++;
                }
            }
            Console.WriteLine(string.Concat(sb.ToString()));
        }
    }
}
