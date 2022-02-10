using System;
using System.Linq;

namespace P02_Trophon_the_Grumpy_Cat
{
    class Trophon_the_Grumpy_Cat
    {
        static void Main()
        {
            int[] priceRatings = Console.ReadLine()
                .Split(' ')
                .Select(int.Parse)
                .ToArray();

            int index = int.Parse(Console.ReadLine());
            string typeItems = Console.ReadLine();
            string typeOfPrice = Console.ReadLine();
            int damageLeft = 0;
            int damageRight = 0;

            for (int i = 0; i < index; i++)
            {
                if (typeItems == "cheap")
                {
                    if (typeOfPrice == "positive")
                    {
                        if (priceRatings[i] < priceRatings[index] && priceRatings[i] > 0)
                        {
                            damageLeft += priceRatings[i];
                        }
                    }
                    else if (typeOfPrice == "negative")
                    {
                        if (priceRatings[i] < priceRatings[index] && priceRatings[i] < 0)
                        {
                            damageLeft += priceRatings[i];
                        }
                    }
                    else if (typeOfPrice == "all")
                    {
                        if (priceRatings[i] < priceRatings[index])
                        {
                            damageLeft += priceRatings[i];
                        }
                    }
                }
                else if (typeItems == "expensive")
                {

                    if (typeOfPrice == "positive")
                    {
                        if (priceRatings[i] >= priceRatings[index] && priceRatings[i] > 0)
                        {
                            damageLeft += priceRatings[i];
                        }
                    }
                    else if (typeOfPrice == "negative")
                    {
                        if (priceRatings[i] >= priceRatings[index] && priceRatings[i] < 0)
                        {
                            damageLeft += priceRatings[i];
                        }
                    }
                    else if (typeOfPrice == "all")
                    {
                        if (priceRatings[i] >= priceRatings[index])
                        {
                            damageLeft += priceRatings[i];
                        }
                    }

                }

            }

            for (int i = index + 1; i < priceRatings.Length; i++)
            {
                if (typeItems == "cheap")
                {
                    if (typeOfPrice == "positive")
                    {
                        if (priceRatings[i] < priceRatings[index] && priceRatings[i] > 0)
                        {
                            damageRight += priceRatings[i];
                        }
                    }
                    else if (typeOfPrice == "negative")
                    {
                        if (priceRatings[i] < priceRatings[index] && priceRatings[i] < 0)
                        {
                            damageRight += priceRatings[i];
                        }
                    }
                    else if (typeOfPrice == "all")
                    {
                        if (priceRatings[i] < priceRatings[index])
                        {
                            damageRight += priceRatings[i];
                        }
                    }
                }
                else if (typeItems == "expensive")
                {

                    if (typeOfPrice == "positive")
                    {
                        if (priceRatings[i] >= priceRatings[index] && priceRatings[i] > 0)
                        {
                            damageRight += priceRatings[i];
                        }
                    }
                    else if (typeOfPrice == "negative")
                    {
                        if (priceRatings[i] >= priceRatings[index] && priceRatings[i] < 0)
                        {
                            damageRight += priceRatings[i];
                        }
                    }
                    else if (typeOfPrice == "all")
                    {
                        if (priceRatings[i] >= priceRatings[index])
                        {
                            damageRight += priceRatings[i];
                        }
                    }

                }

            }
            if (damageLeft > damageRight)
            {
                Console.WriteLine($"Left - {damageLeft}");
            }
            else if (damageRight > damageLeft)
            {
                Console.WriteLine($"Right - {damageRight}");
            }
            else
            {
                Console.WriteLine($"Left - {damageLeft}");
            }
        }
    }
}