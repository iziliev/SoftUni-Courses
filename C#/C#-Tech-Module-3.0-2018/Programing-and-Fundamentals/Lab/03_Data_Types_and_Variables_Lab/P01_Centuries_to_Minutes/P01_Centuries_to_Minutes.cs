namespace P01_Centuries_to_Minutes
{
    using System;
    class P01_Centuries_to_Minutes
    {
        static void Main()
        {
            int centures = int.Parse(Console.ReadLine());

            int years = centures * 100;
            int days = (int)(years * 365.2422);
            int hours = days * 24;
            int minutes = hours * 60;

            Console.WriteLine($"{centures} = {years} = {days} = {hours} = {minutes}");
        }
    }
}
