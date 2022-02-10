using System;

namespace P10_Cube_Properties
{
    class Cube_Properties
    {
        static void Main()
        {
            double side = double.Parse(Console.ReadLine());
            string command = Console.ReadLine();
            switch (command)
            {
                case "volume":
                    Console.WriteLine("{0:F2}", Volume(side));
                    break;
                case "area":
                    Console.WriteLine("{0:F2}", Area(side));
                    break;
                case "face":
                    Console.WriteLine("{0:F2}", Face(side));
                    break;
                case "space":
                    Console.WriteLine("{0:F2}", Space(side));
                    break;
            }

        }
        static double Volume(double side)
        {
            return Math.Pow(side, 3);
        }
        static double Area(double side)
        {
            return 6*Math.Pow(side, 2);
        }
        static double Face(double side)
        {
            return Math.Sqrt(2*Math.Pow(side,2));
        }
        static double Space(double side)
        {
            return Math.Sqrt(3 * Math.Pow(side, 2));
        }
    }
}
