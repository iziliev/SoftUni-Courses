using System;

namespace GenericBoxOfString
{
    public class StartUp
    {
        public static void Main()
        {
            var box = new Box<string>();

            var n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                box.Add(Console.ReadLine());
            }

            Console.WriteLine(box);
        }
    }
}
