using System;
using System.Text;

namespace P04_Morse_Code_Upgraded
{
    class Morse_Code_Upgraded
    {
        static void Main()
        {
            string[] text = Console.ReadLine()
                .Split('|');

            StringBuilder sb = new StringBuilder();

            for (int i = 0; i < text.Length; i++)
            {
                string code = text[i];
                int sum = 0;

                for (int j = 0; j < code.Length; j++)
                {
                    int number = int.Parse(code[j].ToString());

                    if (number == 1)
                    {
                        sum += 5;
                    }
                    else
                    {
                        sum += 3;
                    }
                }

                int countEqual = 1;
                int maxequal = 0;
                for (int j = 1; j < code.Length; j++)
                {
                    if (code[j] == code[j-1])
                    {
                        countEqual++;
                        if (maxequal < countEqual)
                        {
                            maxequal = countEqual;
                        }
                    }
                    else
                    {
                        if (maxequal>1)
                        {
                            sum += maxequal;
                            maxequal = 0;
                            countEqual = 1;
                        }
                        else
                        {
                            maxequal = 0;
                            countEqual = 1;
                        }
                    }                   
                }
                if (maxequal>0)
                {
                    sum += maxequal;
                }
                char letter = (char)sum;
                sb.Append(letter);
            }
            Console.WriteLine(string.Concat(sb.ToString()));
        }
    }
}
