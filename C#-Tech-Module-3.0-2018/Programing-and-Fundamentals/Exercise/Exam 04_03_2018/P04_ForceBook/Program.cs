using System;
using System.Collections.Generic;
using System.Linq;

namespace P04_ForceBook
{
    class User
    {
        public string ForceSide { get; set; }
        public string ForceUser { get; set; }

        public User(string forceSide, string forceUser)
        {
            ForceSide = forceSide;
            ForceUser = forceUser;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            string line = Console.ReadLine();

            var table = new Dictionary<string, List<User>>();
            var list = new List<User>();

            while (line != "Lumpawaroo")
            {
                if (line.Contains('|'))
                {
                    string[] data = line.Split('|');

                    string forceSide = data[0].Trim(' ');
                    string forceUser = data[1].Trim(' ');

                    var user = new User(forceSide, forceUser);

                    if (!table.ContainsKey(forceSide))
                    {
                        table[forceSide] = new List<User>();
                        table[forceSide].Add(user);
                    }
                }

                else
                {
                    string[] data = line.Split("->".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);

                    string forceSide = data[1].Trim(' ');
                    string forceUser = data[0].Trim(' ');

                    //var user = new User(forceSide, forceUser);

                    if (!table.ContainsKey(forceSide))
                    {
                        table[forceSide] = new List<User>();
                    }
                    else
                    {
                        var bycurrentName = table[forceUser];

                        var found = bycurrentName.FirstOrDefault(d => d.ForceUser == forceUser);

                        if (found == null)
                        {
                            found.ForceSide = forceUser;
                        }

                        else
                        {
                            var user = new User(forceSide, forceUser);

                            bycurrentName.Add(user);

                            list.Add(user);

                            table[forceSide].Add(user);
                            Console.WriteLine($"{forceUser} joins the {forceSide} side!");


                        }
                    }
                    

                }

                line = Console.ReadLine();
            }

            foreach (var item in table.OrderBy(x => x.Key))
            {
                if (item.Value.Count > 0)
                {
                    Console.WriteLine($"Side: {item.Key}, Members: {item.Value.Count}");

                    foreach (var items in item.Value.OrderBy(x => x.ForceUser))
                    {
                        Console.WriteLine($"! {items.ForceUser}");
                    }
                }




            }

        }
    }
}
