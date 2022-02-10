using System;
using System.Collections.Generic;
using System.Linq;

namespace P07_Take_Skip_Rope
{
    class Take_Skip_Rope
    {
        static void Main()
        {
            string input = Console.ReadLine();

            List<int> numberList = new List<int>();
            List<char> charList = new List<char>();

            for (int i = 0; i < input.Length; i++)
            {
                if (char.IsDigit(input[i]))
                {
                    string num = input[i].ToString();
                    numberList.Add(int.Parse(num));
                }
                else
                {
                    charList.Add(input[i]);
                }
            }

            int take = 0;
            int skip = 0;
            char[] charArray = charList.ToArray();
            string str = new string(charArray);

            string resultat = string.Empty;

            for (int i = 0; i < numberList.Count; i += 2)
            {
                take = numberList[i];
                var result = charArray.Skip(skip).Take(take).ToArray();

                for (int j = 0; j < result.Length; j++)
                {
                    resultat += result[j];
                }
                skip += (take + numberList[i + 1]);

            }

            Console.WriteLine(resultat);
        }
    }
}
