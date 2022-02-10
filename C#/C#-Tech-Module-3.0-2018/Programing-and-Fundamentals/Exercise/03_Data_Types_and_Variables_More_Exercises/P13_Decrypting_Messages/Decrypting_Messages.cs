using System;

namespace P13_Decrypting_Messages
{
    class Decrypting_Messages
    {
        static void Main()
        {
            int key = int.Parse(Console.ReadLine());
            int n = int.Parse(Console.ReadLine());
            string message = string.Empty;
            for (int i = 0; i < n; i++)
            {
                char letter = char.Parse(Console.ReadLine());
                int num = Convert.ToInt32(letter)+key;
                char decriptedLetters = Convert.ToChar(num);
                message += decriptedLetters;
            }
            Console.WriteLine(message);
        }
    }
}
