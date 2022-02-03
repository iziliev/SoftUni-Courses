using System;
using System.IO;

namespace LineNumbers
{
    public class LineNumbers
    {
        public static void Main()
        {
            string inputFilePath = @"..\..\..\Files\input.txt";
            string outputFilePath = @"..\..\..\Files\output.txt";

            RewriteFileWithLineNumbers(inputFilePath, outputFilePath);
        }

        public static void RewriteFileWithLineNumbers(string inputFilePath, string outputFilePath)
        {
            using StreamReader sr=new StreamReader(inputFilePath);
            using StreamWriter sw = new StreamWriter(outputFilePath);

            var count = 1;
            while (!sr.EndOfStream)
            {
                var line = sr.ReadLine();

                sw.WriteLine($"{count}. {line}");

                count++;
            }
        }

    }
}
