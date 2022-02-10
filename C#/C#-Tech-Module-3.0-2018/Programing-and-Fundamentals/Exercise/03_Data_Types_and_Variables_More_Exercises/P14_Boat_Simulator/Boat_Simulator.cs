using System;

namespace P14_Boat_Simulator
{
    class Boat_Simulator
    {
        static void Main()
        {
            char simbolOne = char.Parse(Console.ReadLine());
            char simbolTwo = char.Parse(Console.ReadLine());
            int n = int.Parse(Console.ReadLine());
            int countOne = 0;
            int countTwo = 0;

            for (int i = 0; i < n; i++)
            {
                string input = Console.ReadLine();

                if (countOne < 50 && countTwo < 50)
                {
                    if (input == "UPGRADE")
                    {
                        simbolOne = (char)(simbolOne + 3);
                        simbolTwo = (char)(simbolTwo + 3);
                    }
                    else
                    {
                        if (i % 2 == 0)
                        {
                            int lenght = input.Length;
                            countOne += lenght;
                        }
                        else
                        {
                            int lenght = input.Length;
                            countTwo += lenght;
                        }
                    }

                }
            }
            if (countOne > countTwo)
            {
                Console.WriteLine($"{simbolOne}");
            }
            else
            {
                Console.WriteLine($"{simbolTwo}");
            }

        }
    }
}
