using System;
using System.Collections.Generic;
using System.Linq;

namespace P02_Phonebook_Upgrade
{
    class Phonebook_Upgrade
    {
        static void Main()
        {
            string[] input = Console.ReadLine()
                .Split(' ');

            Dictionary<string, string> phoneBook = new Dictionary<string, string>();

            while (input[0]!="END")
            {
                if (input[0] == "A")
                {
                    string name = input[1];
                    string tel = input[2];

                    if (!phoneBook.ContainsKey(name))
                    {
                        phoneBook.Add(name, tel);
                    }
                    else
                    {
                        phoneBook[name] = tel;
                    }
                }
                else if (input[0] == "S")
                {
                    string name = input[1];
                    if (!phoneBook.ContainsKey(name))
                    {
                        Console.WriteLine($"Contact {name} does not exist.");
                    }
                    else
                    {
                        foreach (var item in phoneBook)
                        {
                            if (name == item.Key)
                            {
                                Console.WriteLine($"{item.Key} -> {item.Value}");
                            }
                        }
                    }
                }
                else if (input[0] == "ListAll")
                {
                    foreach (var item in phoneBook.OrderBy(w => w.Key))
                    {
                        Console.WriteLine($"{item.Key} -> {item.Value}");
                    }
                }
                input = Console.ReadLine()
                .Split(' ');
            }
        }
    }
}
