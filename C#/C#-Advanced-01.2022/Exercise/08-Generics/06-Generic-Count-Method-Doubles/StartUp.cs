using System;

namespace GenericCountMethodDoubles
{
    public class StartUp
    {
        public static void Main()
        {
            var box = new Box<double>();

            var n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                box.Add(double.Parse(Console.ReadLine()));
            }

            var item = double.Parse(Console.ReadLine());

            Console.WriteLine(box.CompareBoxItems(item));
        }
    }
}
