namespace P12_Convert_Speed_Units
{
    using System;
    class Convert_Speed_Units
    {
        static void Main()
        {
            float meter = float.Parse(Console.ReadLine());
            float hours = float.Parse(Console.ReadLine());
            float minutes = float.Parse(Console.ReadLine());
            float seconds = float.Parse(Console.ReadLine());

            float sumSeconds = hours * 3600 + minutes * 60 + seconds;
            float sumHours = hours + minutes / 60 + seconds / 3600;

            Console.WriteLine(meter / sumSeconds);
            Console.WriteLine(meter / 1000 / sumHours);
            Console.WriteLine(meter / 1609 / sumHours);
        }
    }
}
