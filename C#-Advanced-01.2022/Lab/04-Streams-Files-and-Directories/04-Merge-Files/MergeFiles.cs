using System;
using System.IO;

namespace MergeFiles
{
    public class MergeFiles
    {
        public static void Main()
        {

            string firstInputFilePath = @"..\..\..\input1.txt";
            string secondInputFilePath = @"..\..\..\input2.txt";
            string outputFilePath = @"..\..\..\output.txt";

            MergeTextFiles(firstInputFilePath, secondInputFilePath, outputFilePath);

        }
        public static void MergeTextFiles(string firstInputFilePath, string secondInputFilePath, string outputFilePath)
        {
            using StreamReader srOne = new StreamReader(firstInputFilePath);
            using StreamReader srTwo = new StreamReader(secondInputFilePath);
            using StreamWriter sw = new StreamWriter(outputFilePath);

            while (!srOne.EndOfStream && !srTwo.EndOfStream)
            {
                if (!srOne.EndOfStream)
                {
                    sw.WriteLine(srOne.ReadLine());
                }
                if (!srTwo.EndOfStream)
                {
                    sw.WriteLine(srTwo.ReadLine());
                }
                
            }
           
        }

    }
}