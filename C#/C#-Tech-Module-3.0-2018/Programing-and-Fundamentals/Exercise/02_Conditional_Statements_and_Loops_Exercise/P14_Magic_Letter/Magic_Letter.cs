namespace P14_Magic_Letter
{
    using System;
    class Magic_Letter
    {
        static void Main()
        {
            char firstLetter = char.Parse(Console.ReadLine());
            char secondLetter = char.Parse(Console.ReadLine());
            char keyLetter = char.Parse(Console.ReadLine());

            for (char i = firstLetter; i <= secondLetter; i++)
            {
                for (char j = firstLetter; j <= secondLetter; j++)
                {
                    for (char k = firstLetter; k <= secondLetter; k++)
                    {
                        if (i!=keyLetter && j!=keyLetter && k!=keyLetter)
                        {
                            Console.Write($"{i}{j}{k} "); 
                        }
                    }
                }
            }
            Console.WriteLine();
        }
    }
}
