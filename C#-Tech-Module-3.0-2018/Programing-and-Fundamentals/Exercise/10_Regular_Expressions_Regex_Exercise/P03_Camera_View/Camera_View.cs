using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace P03_Camera_View
{
    class Camera_View
    {
        static void Main()
        {
            int[] elemrns = Console.ReadLine()
                .Split(' ')
                .Select(int.Parse)
                .ToArray();

            string text = Console.ReadLine();

            string pattern = @"(\|<)([\w]+)";

            Regex regex = new Regex(pattern);

            var matches = regex.Matches(text);

            List<string> cameraView = new List<string>();

            foreach (Match item in matches)
            {
                string cameraText = item.Groups[2].Value.ToString();

                var views = string.Concat(cameraText.Skip(elemrns[0]).Take(elemrns[1]));

                cameraView.Add(views);
            }
            Console.WriteLine(string.Join(", ",cameraView));
        }
    }
}
