using System;

namespace _04_Pizza_Calories
{
    public class StartUp
    {
        public static void Main()
        {
            var input = string.Empty;

            var pizzaInput = Console.ReadLine().Split(" ");
            var doughInput = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

            try
            {
                var dought = new Dough(doughInput[1], doughInput[2], int.Parse(doughInput[3]));
                var pizza = new Pizza(pizzaInput[1], dought);

                while ((input = Console.ReadLine()) != "END")
                {
                    var toppingInput = input.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                    var topping = new Topping(toppingInput[1], int.Parse(toppingInput[2]));
                    pizza.AddTopping(topping);
                }

                Console.WriteLine(pizza);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

        }
    }
}
