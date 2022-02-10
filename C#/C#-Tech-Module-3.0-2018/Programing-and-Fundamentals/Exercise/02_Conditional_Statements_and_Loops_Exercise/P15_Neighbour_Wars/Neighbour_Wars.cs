namespace P15_Neighbour_Wars
{
    using System;
    class Neighbour_Wars
    {
        static void Main()
        {
            int peshoDamage = int.Parse(Console.ReadLine());
            int goshoDamage = int.Parse(Console.ReadLine());

            int peshoHealth = 100;
            int goshoHealth = 100;

            string peshoKick = "Roundhouse kick";
            string goshoKick = "Thunderous fist";

            int turn = 0;
            int count = 0;
            while (peshoHealth > 0 && goshoHealth > 0)
            {
                turn++;
                if (turn % 2 != 0)
                {
                    goshoHealth -= peshoDamage;
                    if (goshoHealth > 0)
                    {
                        Console.WriteLine($"Pesho used {peshoKick} and reduced Gosho to {goshoHealth} health.");
                    }
                    else
                    {
                        break;
                    }
                    
                }
                else
                {
                    peshoHealth -= goshoDamage;

                    if (peshoHealth > 0)
                    {
                        Console.WriteLine($"Gosho used {goshoKick} and reduced Pesho to {peshoHealth} health.");
                    }
                    else
                    {
                        break;
                    }
                    
                }
                if (turn % 3 == 0 )
                {
                    peshoHealth += 10;
                    goshoHealth += 10;
                }
                
            }
            if (peshoHealth <= 0)
            {
                Console.WriteLine($"Gosho won in {turn}th round.");
            }
            else
            {
                Console.WriteLine($"Pesho won in {turn}th round.");
            }
        }
    }
}
