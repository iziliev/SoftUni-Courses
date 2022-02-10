namespace P02_Vapor_Store
{
    using System;
    class Vapor_Store
    {
        static void Main()
        {
            double currentBalance = double.Parse(Console.ReadLine());

            string command = "Game Time";

            string gameOne = "OutFall 4";
            string gameTwo = "CS: OG";
            string gameThree = "Zplinter Zell";
            string gameFour = "Honored 2";
            string gameFive = "RoverWatch";
            string gameSix = "RoverWatch Origins Edition";

            double priceGameOne = 39.99;
            double priceGameTwo = 15.99;
            double priceGameThree = 19.99;
            double priceGameFour = 59.99;
            double priceGameFive = 29.99;
            double priceGameSix = 39.99;

            double count = 0;
            for (int i = 1; i <= 5000; i++)
            {
                string game = Console.ReadLine();

                if (game != command)
                {
                    if (currentBalance > 0)
                    {
                        if (game == gameOne && currentBalance >= priceGameOne)
                        {
                            currentBalance -= priceGameOne;
                            count += priceGameOne;
                            Console.WriteLine("Bought {0}", gameOne);
                        }
                        else if (game == gameTwo && currentBalance >= priceGameTwo)
                        {
                            currentBalance -= priceGameTwo;
                            count += priceGameTwo;
                            Console.WriteLine("Bought {0}", gameTwo);
                        }
                        else if (game == gameThree && currentBalance >= priceGameThree)
                        {
                            currentBalance -= priceGameThree;
                            count += priceGameThree;
                            Console.WriteLine("Bought {0}", gameThree);
                        }
                        else if (game == gameFour && currentBalance >= priceGameFour)
                        {
                            currentBalance -= priceGameFour;
                            count += priceGameFour;
                            Console.WriteLine("Bought {0}", gameFour);
                        }
                        else if (game == gameFive && currentBalance >= priceGameFive)
                        {
                            currentBalance -= priceGameFive;
                            count += priceGameFive;
                            Console.WriteLine("Bought {0}", gameFive);
                        }
                        else if (game == gameSix && currentBalance >= priceGameSix)
                        {
                            currentBalance -= priceGameSix;
                            count += priceGameSix;
                            Console.WriteLine("Bought {0}", gameSix);
                        }
                        else if (game != gameOne &&
                                game != gameTwo &&
                                game != gameThree &&
                                game != gameFour &&
                                game != gameFive &&
                                game != gameSix)
                        {
                            Console.WriteLine("Not Found");

                        }
                        else
                        {
                            Console.WriteLine("Too Expensive");
                        }
                    }

                }
                else if (command == game)
                {
                    if (currentBalance > 0)
                    {
                        Console.WriteLine("Total spent: ${0:f2}. Remaining: ${1:f2}", count, currentBalance);
                        return;
                    }
                    else
                    {
                        Console.WriteLine("Out of money!");
                        return;
                    }
                }

            }
        }
    }
}
