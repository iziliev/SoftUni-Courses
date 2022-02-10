namespace P13_Vowel_or_Digit
{
    using System;
    class Vowel_or_Digit
    {
        static void Main()
        {
            string input = Console.ReadLine();

            try
            {
                decimal num = decimal.Parse(input);
                Console.WriteLine("digit");
            }
            catch (Exception)
            {
                char letter = char.Parse(input);
                if (letter == 'a' ||
                    letter == 'e' ||
                    letter == 'i' ||
                    letter == 'o' ||
                    letter == 'u')
                {
                    Console.WriteLine("vowel");
                }
                else
                {
                    Console.WriteLine("other");
                }
            }
        }
    }
}
