using System;
using System.Collections.Generic;

namespace P06_Byte_Flip
{
    class Byte_Flip
    {
        static void Main()
        {
            string[] input = Console.ReadLine()
                .Split(' ');

            List<string> list = new List<string>();

            for (int i = 0; i < input.Length; i++)
            {
                string n = input[i];
                if (n.Length == 2)
                {
                    char[] str = n.ToCharArray();
                    Array.Reverse(str);
                    string xex = new string(str);
                    list.Add(xex);
                }
            }
            list.Reverse();
            string output = string.Empty;

            for (int i = 0; i < list.Count; i++)
            {
                int value = Convert.ToInt32(list[i],16);
                char charValue = (char)value;
                output += charValue;
            }
            Console.WriteLine($"{output}");
        }
    }
}
