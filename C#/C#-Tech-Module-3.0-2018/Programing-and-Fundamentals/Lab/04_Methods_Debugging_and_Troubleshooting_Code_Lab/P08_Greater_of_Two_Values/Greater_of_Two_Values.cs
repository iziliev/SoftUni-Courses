using System;

namespace P08_Greater_of_Two_Values
{
    class Greater_of_Two_Values
    {
        static void Main()
        {
            string command = Console.ReadLine();
            if (command=="int")
            {
                int first = int.Parse(Console.ReadLine());
                int second = int.Parse(Console.ReadLine());
                int result = GetMax(first, second);
                Console.WriteLine(result);
            }
            else if (command == "char")
            {
                char letterOne = char.Parse(Console.ReadLine());
                char letterTwo = char.Parse(Console.ReadLine());
                char result = GetMax(letterOne, letterTwo);
                Console.WriteLine(result);
            }
            else if (command == "string")
            {
                string strA = Console.ReadLine();
                string strB = Console.ReadLine();
                string result = GetMax(strA, strB);
                Console.WriteLine(result);
            }
        }
        static int GetMax(int first,int second)
        {
            if (first>second)
            {
                return first;
            }
            else
            {
                return second;
            }
        }
        static char GetMax(char letterOne, char letterTwo)
        {
            if (letterOne>letterTwo)
            {
                return letterOne;
            }
            else
            {
                return letterTwo;
            }
        }
        static string GetMax(string strA, string strB)
        {
            var result = strA.CompareTo(strB);
            if (result < 0)
            {
                return strB;
            }
            else if (result > 0)
            {
                return strA;
            }
            else
            {
                return strA;
            }
        }
    }
}
