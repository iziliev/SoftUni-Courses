using System;
using System.Collections.Generic;
using System.Linq;

namespace P02_Hornet_Comm
{
    class Hornet_Comm
    {
        static void Main()
        {
            string input = Console.ReadLine();

            Dictionary<string, List<string>> privateMessage = new Dictionary<string, List<string>>();
            Dictionary<string, List<string>> broadcast = new Dictionary<string, List<string>>();


            while (input != "Hornet is Green")
            {
                string[] data = input.Split(' ');

                string firstQuery = data[0];
                string secondQuery = data[2];

                bool isDigitOne = firstQuery.All(char.IsDigit);
                bool isDigitTwo = secondQuery.All(char.IsDigit);
                bool isLetterOne = firstQuery.All(char.IsLetter);
                bool isLetterTwo = secondQuery.All(char.IsLetter);

                string recepientCode = "";
                string message = "";
                string frequence = "";

                if (isDigitOne == true && isDigitTwo == true || isLetterTwo == true)
                {
                    recepientCode = firstQuery;
                    message = secondQuery;
                    string reverse = "";
                    for (int i = recepientCode.Length - 1; i >= 0; i--)
                    {
                        reverse += recepientCode[i];
                    }
                    recepientCode = reverse;

                    if (!privateMessage.ContainsKey(recepientCode))
                    {
                        privateMessage.Add(recepientCode, new List<string>());
                    }
                    privateMessage[recepientCode].Add(message);
                }

                else if (isDigitOne == false && isDigitTwo == true || isLetterTwo == true)
                {
                    message = firstQuery;
                    frequence = secondQuery;
                    
                    if (!broadcast.ContainsKey(frequence))
                    {
                        broadcast.Add(frequence, new List<string>());
                    }
                    broadcast[frequence].Add(message);
                }

                else if (isDigitOne == false && isDigitTwo == false)
                {
                    message = firstQuery;
                    frequence = secondQuery;
                    string capitalOrLower = "";
                    
                    for (int i = 0; i < frequence.Length; i++)
                    {

                        if (char.IsLower(frequence[i]))
                        {
                            var letter = frequence[i].ToString().ToUpper();
                            capitalOrLower += letter;
                        }
                        else if (char.IsUpper(frequence[i]))
                        {
                            var letter = frequence[i].ToString().ToUpper();
                            capitalOrLower += letter;
                        }
                        else
                        {
                            capitalOrLower += frequence[i];
                        }
                    }

                    frequence = capitalOrLower;

                    if (!broadcast.ContainsKey(frequence))
                    {
                        broadcast.Add(frequence, new List<string>());
                    }
                    broadcast[frequence].Add(message);
                }
                else
                {
                    input = Console.ReadLine();
                    continue;
                }

                input = Console.ReadLine();
            }

            Console.WriteLine("Broadcasts:");
            foreach (var item in broadcast)
            {
                foreach (var items in item.Value)
                {
                    Console.WriteLine($"{item.Key} -> {items}");
                }
            }
            Console.WriteLine("Messages:");
            if (privateMessage.Count == 0)
            {
                Console.WriteLine("None");
                return;
            }
            else
            {
                foreach (var item in privateMessage)
                {
                    foreach (var items in item.Value)
                    {
                        Console.WriteLine($"{item.Key} -> {items}");
                    }
                }
            }
        }
    }
}
