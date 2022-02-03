using System;
using System.Collections.Generic;

namespace _08_SoftUni_Party
{
    class StartUp
    {
        static void Main()
        {
            var input = string.Empty;

            var vip = new HashSet<string>();
            var other = new HashSet<string>();

            while ((input = Console.ReadLine()) !="PARTY")
            {
                if (input.Length != 8)
                {
                    continue;
                }

                if (char.IsDigit(input[0]))
                {
                    vip.Add(input);
                }
                else
                {
                    other.Add(input);
                }
            }

            while ((input = Console.ReadLine()) != "END")
            {
                if (vip.Contains(input))
                {
                    vip.Remove(input);
                }
                else if (other.Contains(input))
                {
                    other.Remove(input);
                }
            }

            Console.WriteLine(vip.Count+other.Count);

            if (vip.Count>0)
            {
                Console.WriteLine(string.Join("\n",vip));
            }
            if (other.Count > 0)
            {
                Console.WriteLine(string.Join("\n", other));
            }
        }
    }
}
