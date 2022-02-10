using System;
using System.Linq;

namespace P09_Melrah_Shake
{
    class Melrah_Shake
    {
        static void Main(string[] args)
        {
            string text = Console.ReadLine();
            string pattern = Console.ReadLine();


            while (pattern.Length > 0)
            {
                int firstIndex = text.IndexOf(pattern);
                int lastIndex = text.LastIndexOf(pattern);

                if (firstIndex != lastIndex)
                {
                    text = text.Remove(lastIndex, pattern.Length);
                    text = text.Remove(firstIndex, pattern.Length);
                    pattern = pattern.Remove(pattern.Length / 2, 1);
                    Console.WriteLine("Shacked it.");
                }
                else if (firstIndex == lastIndex && firstIndex>0)
                {
                    text = text.Remove(lastIndex, pattern.Length);
                    pattern = pattern.Remove(pattern.Length / 2, 1);
                    Console.WriteLine("Shacked it.");
                }
                else
                {
                    break;
                }
            }
            Console.WriteLine("No shake.");
            Console.WriteLine(text);
        }
    }
}
