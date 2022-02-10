using System;

namespace P02_Email_Me
{
    class Email_Me
    {
        static void Main()
        {
            string[] text = Console.ReadLine()
                .Split('@');

            string textLeft = text[0];
            string textRight = text[1];

            int countLeftChar = 0;
            int countRightChar = 0;

            for (int i = 0; i < textLeft.Length; i++)
            {
                countLeftChar += textLeft[i];
            }
            for (int i = 0; i < textRight.Length; i++)
            {
                countRightChar += textRight[i];
            }

            if (countRightChar - countLeftChar < 0)
            {
                Console.WriteLine("Call her!");
            }
            else
            {
                Console.WriteLine("She is not the one.");
            }
        }
    }
}
