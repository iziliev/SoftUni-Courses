namespace P09_Reverse_Characters
{
    using System;
    class Reverse_Characters
    {
        static void Main()
        {
            char first = char.Parse(Console.ReadLine());
            char second = char.Parse(Console.ReadLine());
            char third = char.Parse(Console.ReadLine());

            char temp = first;
            first = third;
            third = temp;

            Console.WriteLine($"{first}{second}{third}");
        }
    }
}
