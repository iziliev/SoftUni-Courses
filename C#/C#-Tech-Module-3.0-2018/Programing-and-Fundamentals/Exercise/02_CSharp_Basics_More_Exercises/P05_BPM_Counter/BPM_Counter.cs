namespace P05_BPM_Counter
{
    using System;
    class BPM_Counter
    {
        static void Main()
        {
            int bpm = int.Parse(Console.ReadLine());
            int beats = int.Parse(Console.ReadLine());

            double bars = beats / 4.0;
            bars = Math.Round(bars, 1);

            var SecondSum = (beats / (double)bpm) * 60;
            SecondSum = Math.Truncate(SecondSum);
            var seconds = SecondSum % 60;
            int minutes = (int)SecondSum / 60;
            Console.WriteLine($"{bars} bars - {minutes}m {seconds}s");
        }
    }
}
