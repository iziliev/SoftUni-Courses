using System;
using System.Collections.Generic;

namespace P01_Phonebook
{
    class Phonebook
    {
        static void Main()
        {
            string[] input = Console.ReadLine()
                .Split(' ');
            Dictionary<string, string> phoneBook = new Dictionary<string, string>();

            while (input[0] != "END")
            {
                string name = input[1];
                if (input[0] == "A")
                {
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
                input = Console.ReadLine()
                .Split(' ');
            }
        }
    }
}
