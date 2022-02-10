using System;

namespace P01_Hello_Name
{
    class Hello_Name
    {
        static void Main()
        {
            string name = Console.ReadLine();
            var print = PrintName(name);
            Console.WriteLine(print);
        }
        static string PrintName(string name)
        {
            var result = $"Hello, {name}!";
            return result;
        }
    }
}
