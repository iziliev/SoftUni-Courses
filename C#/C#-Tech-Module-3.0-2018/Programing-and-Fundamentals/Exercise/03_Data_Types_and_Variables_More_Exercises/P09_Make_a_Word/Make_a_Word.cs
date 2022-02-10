namespace P09_Make_a_Word
{
    using System;
    class Make_a_Word
    {
        static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            string word = string.Empty;
            for (int i = 0; i < n; i++)
            {
                char letter = char.Parse(Console.ReadLine());
                word += letter;
            }
            Console.WriteLine($"The word is: {word}");
        }
    }
}
