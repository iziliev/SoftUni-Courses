using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace EvenLines
{
    public class EvenLines
    {
        public static void Main()
        {
            string inputFilePath = @"..\..\..\text.txt";

            Console.WriteLine(ProcessLines(inputFilePath));
        }

        public static string ProcessLines(string inputFilePath)
        {
            using StreamReader streamReader = new StreamReader(inputFilePath);

            var sb = new StringBuilder();

            var arraySimbols = new char[] { '-', ',', '.', '!', '?' };
            var count = 0;

            while (!streamReader.EndOfStream)
            {
                var line = streamReader.ReadLine()
                        .Split(" ")
                        .Reverse()
                        .ToArray();

                if (count % 2 == 0)
                {
                    sb.AppendLine(String.Join(" ", line));
                }
                count++;
            }

            var sbText = sb
                .ToString()
                .TrimEnd();

            for (int i = 0; i < arraySimbols.Length; i++)
            {
                sbText = sbText.Replace(arraySimbols[i], '@');
            }

            return sbText.ToString().Trim();
        }
    }
}
