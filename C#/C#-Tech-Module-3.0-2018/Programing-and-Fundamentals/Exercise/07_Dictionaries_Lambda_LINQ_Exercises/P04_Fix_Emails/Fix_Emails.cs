using System;
using System.Collections.Generic;

namespace P04_Fix_Emails
{
    class Fix_Emails
    {
        static void Main()
        {
            Dictionary<string, string> emails = new Dictionary<string, string>();

            string name = Console.ReadLine();

            while (name != "stop")
            {
                string email = Console.ReadLine();

                if (!email.Contains(".uk") && !email.Contains(".us"))
                {
                    if (!emails.ContainsKey(name))
                    {
                        emails.Add(name, email);
                    }
                    else
                    {
                        emails[name] = email;
                    }
                }
                name = Console.ReadLine();
            }

            foreach (var item in emails)
            {
                Console.WriteLine($"{item.Key} -> {item.Value}");
            }
        }
    }
}
