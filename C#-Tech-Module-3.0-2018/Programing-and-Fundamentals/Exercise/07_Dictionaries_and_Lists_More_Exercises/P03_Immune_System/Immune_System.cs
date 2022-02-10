using System;
using System.Collections.Generic;

namespace P03_Immune_System
{
    class Immune_System
    {
        static void Main()
        {
            int health = int.Parse(Console.ReadLine());
            string virusName = Console.ReadLine();
            int finalHealth = health;

            List<string> nameOfVirus = new List<string>();
            bool check = false;
            while (virusName != "end")
            {
                int virusSternght = 0;
                for (int i = 0; i < virusName.Length; i++)
                {
                    string virusLetter = virusName[i].ToString();
                    char virusLetterOne = char.Parse(virusLetter);
                    virusSternght += virusLetterOne;
                }
                virusSternght /= 3;
                int timeToDefeat = 0;

                if (!nameOfVirus.Contains(virusName))
                {
                    nameOfVirus.Add(virusName);
                    timeToDefeat = virusSternght * virusName.Length;
                }
                else
                {
                    timeToDefeat = virusSternght * virusName.Length/3;
                }
                
                int minutes = timeToDefeat / 60;
                int seconds = timeToDefeat % 60;

                int control = health - timeToDefeat;

                
                if (control > 0)
                {
                    Console.WriteLine($"Virus {virusName}: {virusSternght} => {timeToDefeat} seconds");
                    Console.WriteLine($"{virusName} defeated in {minutes}m {seconds}s.");
                    Console.WriteLine($"Remaining health: {control}");

                    if (control * 0.2 + control < health)
                    {
                        health = (int)(control * 0.2 + control);
                    }
                    check = true;
                }
                else
                {
                    Console.WriteLine($"Virus {virusName}: {virusSternght} => {timeToDefeat} seconds");
                    check = false;
                    break;
                }
                
                virusName = Console.ReadLine();
            }
            if (check==false)
            {
                Console.WriteLine("Immune System Defeated.");
            }
            else
            {
                Console.WriteLine($"Final Health: {health}");
            }
            
        }
    }
}
