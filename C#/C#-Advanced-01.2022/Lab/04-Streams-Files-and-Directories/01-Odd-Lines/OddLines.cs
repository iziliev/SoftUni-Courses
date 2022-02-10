using System;
using System.IO;

namespace OddLines
{
    public class OddLines
    {
        public static void Main()
        {
            var inputFilePath = @"..\..\..\Files\input.txt";
            var outputFilePath = @"..\..\..\Files\output.txt";

            ExtractOddLines(inputFilePath, outputFilePath);
        }

        public static void ExtractOddLines(string inputFilePath, string outputFilePath)
        {
            using StreamReader sr = new StreamReader(inputFilePath);
            using StreamWriter sw = new StreamWriter(outputFilePath);

            var count = 0;
            while (!sr.EndOfStream)
            {
                var line  = sr.ReadLine();
                if (count%2 == 1)
                {
                    sw.WriteLine(line);
                }
                count++;
            }
        }

    }
}
