namespace P05_Character_Stats
{
    using System;
    class Character_Stats
    {
        static void Main()
        {
            string name = Console.ReadLine();
            int health = int.Parse(Console.ReadLine());
            int maxHealth = int.Parse(Console.ReadLine());
            int energy = int.Parse(Console.ReadLine());
            int maxEnergy = int.Parse(Console.ReadLine());

            Console.WriteLine($"Name: {name}");
            Console.WriteLine("Health: |{0}{1}|",
                new string('|',health),
                new string('.',maxHealth-health));
            Console.WriteLine("Energy: |{0}{1}|",
                new string('|', energy),
                new string('.', maxEnergy - energy));
        }
    }
}
