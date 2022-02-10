using System;
using System.Collections.Generic;

namespace _07_Parking_Lot
{
    class StartUp
    {
        static void Main()
        {
            var input = string.Empty;

            var parking = new HashSet<string>();

            while ((input=Console.ReadLine()) != "END")
            {
                var data = input
                    .Split(", ", StringSplitOptions.RemoveEmptyEntries);

                if (data[0]=="IN")
                {
                    parking.Add(data[1]);
                }
                else if (data[0] == "OUT" && parking.Contains(data[1]))
                {
                    parking.Remove(data[1]);
                }
            }

            if (parking.Count>0)
            {
                foreach (var item in parking)
                {
                    Console.WriteLine(item);
                }
            }
            else
            {
                Console.WriteLine("Parking Lot is Empty");
            }
        }
    }
}
