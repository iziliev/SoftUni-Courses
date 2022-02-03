using System;
using System.IO;
using System.Linq;
using System.Text;

namespace LineNumbers
{
    public class LineNumbers
    {
        public static void Main()
        {
            var inputFilePath = @"..\..\..\text.txt";
            var outputFilePath = @"..\..\..\output.txt";

            ProcessLines(inputFilePath, outputFilePath);
        }
        public static void ProcessLines(string inputFilePath, string outputFilePath)
        {
            
            //By File
            var enumLines = File.ReadLines(inputFilePath, Encoding.UTF8);
            
            var count = 1;

            foreach (var line in enumLines)
            {
                var charsInLine = line.Where(x => char.IsLetter(x)).ToArray().Length;
                var punctuals = line.Where(x => char.IsPunctuation(x)).ToArray().Length;

                if (count==1)
                {
                    File.WriteAllText(outputFilePath, $"Line {count++}: {line} ({charsInLine})({punctuals}) \n");
                }
                else
                {
                    File.AppendAllText(outputFilePath, $"Line {count++}: {line} ({charsInLine})({punctuals}) \n");
                }
            }

            //By Streem
            //using StreamReader sr = new StreamReader(inputFilePath);
            //using StreamWriter sw = new StreamWriter(outputFilePath);

            //var count = 1;
            //while (!sr.EndOfStream)
            //{
            //    var line = sr.ReadLine();
            //    var lettersNum = line.Where(x => char.IsLetter(x)).ToArray().Length;
            //    var numOfPunctual = line.Where(c => char.IsPunctuation(c)).ToArray().Length;

            //    sw.WriteLine($"Line{count++}: {line} ({lettersNum})({numOfPunctual})");
            //}
        }

    }
}
