using System;

namespace P03_Unicode_Characters
{
    class Unicode_Characters
    {
        static void Main()
        {
            string input = Console.ReadLine();
            string[] result = new string[input.Length];

            for (int i = 0; i < input.Length; i++)
            {
                result[i] = String.Format("{0:x4}", (int)input[i]);
            }
            Console.Write("\\u");
            Console.WriteLine(String.Join("\\u",result));
        }
    }
}
