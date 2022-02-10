using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace WordCount
{
    public class WordCount
    {
        public static void Main()
        {
            string wordsFilePath = @"..\..\..\words.txt";
            string textFilePath = @"..\..\..\text.txt";
            string outputFilePath = @"..\..\..\output.txt";

            CalculateWordCounts(wordsFilePath, textFilePath, outputFilePath);

        }
        public static void CalculateWordCounts(string wordsFilePath, string textFilePath, string outputFilePath)
        {
            using StreamReader srWord = new StreamReader(wordsFilePath);
            using StreamReader srText = new StreamReader(textFilePath);
            using StreamWriter sw = new StreamWriter(outputFilePath);

            var listOfWords = new Dictionary<string, int>();

            while (!srWord.EndOfStream)
            {
                var line = srWord.ReadLine()
                    .Split(" ");

                foreach (var item in line)
                {
                    if (!listOfWords.ContainsKey(item.ToLower()))
                    {
                        listOfWords[item] = 0;
                    }
                }
            }

            while (!srText.EndOfStream)
            {
                var line = srText.ReadLine().ToLower()
                    .Split(new char[] { ',', '.', '!', '?', ' ', '-' }, StringSplitOptions.RemoveEmptyEntries);

                foreach (var item in line)
                {
                    var word = item.ToLower();
                    
                    if (listOfWords.ContainsKey(word))
                    {
                        listOfWords[item]++;
                    }
                }
            }

            foreach (var item in listOfWords.OrderByDescending(x => x.Value))
            {
                sw.WriteLine($"{item.Key} - {item.Value}");
            }
        }

    }
}
