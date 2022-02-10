using System;
using System.Text.RegularExpressions;

namespace P06_Valid_Usernames
{
    class Valid_Usernames
    {
        static void Main()
        {
            string input = Console.ReadLine();
                
            string pattern = @"\b([A-Za-z]\w{2,24})\b";

            Regex regex = new Regex(pattern);

            var match = regex.Matches(input);

            string[] emails = new string[match.Count];

            int count = 0;

            foreach (Match item in match)
            {
                emails[count] = item.Value;
                count++;
            }
            int maxSum = 0;
            string[] winner = new string[2];
            
            for (int i = 0; i < emails.Length-1; i++)
            {
                string firstUser = emails[i];
                string secondUser = emails[i + 1];
                int currentSum = firstUser.Length + secondUser.Length;

                if (currentSum > maxSum)
                {
                    maxSum = currentSum;
                    winner[0] = firstUser;
                    winner[1] = secondUser;
                }
            }

            foreach (var item in winner)
            {
                Console.WriteLine(item);
            }
        }
    }
}
