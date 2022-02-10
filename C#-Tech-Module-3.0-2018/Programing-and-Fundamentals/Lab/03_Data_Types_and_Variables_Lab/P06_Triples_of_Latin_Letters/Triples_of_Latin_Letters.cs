namespace P06_Triples_of_Latin_Letters
{
    using System;
    class Triples_of_Latin_Letters
    {
        static void Main()
        {
            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    for (int k = 0; k < n; k++)
                    {
                        char letterOne = (char)('a' + i);
                        char letterTwo = (char)('a' + j);
                        char letterThree = (char)('a' + k);

                        Console.WriteLine($"{letterOne}{letterTwo}{letterThree}");
                    }
                }
            }
        }
    }
}
