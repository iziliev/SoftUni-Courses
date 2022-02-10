using System;
using System.Collections.Generic;
using System.Text;

namespace _10_Crossroads
{
    class StartUp
    {
        static void Main()
        {
            var greenLight = int.Parse(Console.ReadLine());

            var freeWindow = int.Parse(Console.ReadLine());

            var green = greenLight;

            var queue = new Queue<string>();

            var input = string.Empty;
            var passedCars = 0;
            var isCrashed = false;
            var sb = new StringBuilder();

            while ((input = Console.ReadLine()) != "END")
            {
                if (isCrashed)
                {
                    continue;
                }
                if (input != "green")
                {
                    queue.Enqueue(input);
                }
                else
                {
                    while (queue.Count > 0 && green - queue.Peek().Length > 0)
                    {
                        green -= queue.Dequeue().Length;
                        passedCars++;
                    }

                    if (queue.Count==0)
                    {
                        green = greenLight;
                        continue;
                    }

                    var car = queue.Dequeue();

                    if (green + freeWindow - car.Length >= 0)
                    {
                        passedCars++;
                        green = greenLight;
                    }
                    else
                    {
                        sb.AppendLine("A crash happened!");
                        sb.AppendLine($"{car} was hit at {car[green + freeWindow]}.");
                        isCrashed = true;
                    }
                }
                
            }
            if (!isCrashed)
            {
                Console.WriteLine("Everyone is safe.");
                Console.WriteLine($"{passedCars} total cars passed the crossroads.");
            }
            else
            {
                Console.WriteLine(sb.ToString().Trim());
            }
        }
    }
}
