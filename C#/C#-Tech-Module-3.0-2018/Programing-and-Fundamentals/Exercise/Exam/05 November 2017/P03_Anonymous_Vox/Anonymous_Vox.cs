using System;
using System.Text.RegularExpressions;

namespace P03_Anonymous_Vox
{
    class Anonymous_Vox
    {
        static void Main()
        {
            string text = Console.ReadLine();
            string[] replaceText = Console.ReadLine()
                .Split("{}".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);

            string pattren = @"([A-Za-z]+)(?<placeholder>.+)(\1)";

            Regex regex = new Regex(pattren);

            var matches = Regex.Matches(text, pattren);

            int count = 0;

            foreach (Match item in matches)
            {
                for (int i = count; i < replaceText.Length; i++)
                {
                    string textRep = item.Groups["placeholder"].Value;
                    text = text.Replace(textRep, replaceText[i]);
                }
                count++;
            }
            Console.WriteLine(text);
        }
    }
}
