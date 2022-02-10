namespace P10_Centuries_to_Nanoseconds
{
    using System;
    class Centuries_to_Nanoseconds
    {
        static void Main()
        {
            byte centures = byte.Parse(Console.ReadLine());
            short years = (short)(centures * 100);
            int days = (int)(years * 365.2422);
            decimal hours = days * 24;
            decimal minutes = hours * 60;
            decimal seconds = minutes * 60;
            decimal miliseconds = seconds * 1000;
            decimal microseconds = miliseconds * 1000;
            decimal nanoseconds = microseconds * 1000;

            Console.WriteLine($"{centures} centuries = {years} years = {days} days = {hours} hours = {minutes} minutes = {seconds} seconds = {miliseconds} milliseconds = {microseconds} microseconds = {nanoseconds} nanoseconds");
        }
    }
}
