using System;
using System.Collections.Generic;
using System.Linq;

namespace P05_Parking_Validation
{
    class Parking_Validation
    {
        static void Main()
        {
            int n = int.Parse(Console.ReadLine());

            Dictionary<string, string> parking = new Dictionary<string, string>();

            for (int i = 0; i < n; i++)
            {
                string[] input = Console.ReadLine()
                    .Split(' ');
                
                bool first = false;
                bool middle = false;
                bool last = false;

                if (input[0] == "register")
                {
                    string user = input[1];
                    string plate = input[2];

                    if(char.IsUpper(plate[0]) &&
					   char.IsUpper(plate[1]) &&
					   char.IsDigit(plate[2]) &&
					   char.IsDigit(plate[3]) &&
					   char.IsDigit(plate[4]) &&
					   char.IsDigit(plate[5]) &&
					   char.IsUpper(plate[6]) &&
					   char.IsUpper(plate[7]))
					{
						if (!parking.ContainsKey(user) && !parking.ContainsValue(plate))
                        {
                            parking.Add(user, plate);
                            Console.WriteLine($"{user} registered {plate} successfully");
                        }
                        else
                        {
                            if (parking.ContainsKey(user))
                            {
                                Console.WriteLine($"ERROR: already registered with plate number {plate}");
                            }
                            else if (parking.ContainsValue(plate))
                            {
                                Console.WriteLine($"ERROR: license plate {plate} is busy");
                            }
                        }                        
                    }
                    else
                    {
                        Console.WriteLine($"ERROR: invalid license plate {plate}");
                    }
                }
                else if (input[0] == "unregister")
                {
                    string user = input[1];

                    if (!parking.ContainsKey(user))
                    {
                        Console.WriteLine($"ERROR: user {user} not found");
                    }
                    else
                    {
                        parking.Remove(user);
                        Console.WriteLine($"user {user} unregistered successfully");
                    }
                }
            }
            foreach (var item in parking)
            {
                Console.WriteLine($"{item.Key} => {item.Value}");
            }
        }
    }
}
