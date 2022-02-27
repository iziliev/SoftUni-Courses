using System;
using System.Collections.Generic;
using System.Linq;

namespace _03_Shopping_Spree
{
    public class StartUp
    {
        public static void Main()
        {
            var persons = new List<Person>();
            var products = new List<Product>();

            try
            {
                FillPersonAndProdict(persons, products);

                try
                {
                    var input = string.Empty;
                    while ((input = Console.ReadLine()) != "END")
                    {
                        var args = input.Split(' ', StringSplitOptions.RemoveEmptyEntries);
                        var personArgs = args[0];
                        var productArgs = args[1];

                        var product = products.FirstOrDefault(p => p.Name == productArgs);
                        var person = persons.FirstOrDefault(p => p.Name == personArgs);

                        Console.WriteLine(person.BuyProduct(product));
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }

                foreach (var person in persons)
                {
                    Console.WriteLine($"{person.Name} - {person}");
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }           
        }

        private static void FillPersonAndProdict(List<Person> persons, List<Product> products)
        {
            var personsInput = Console.ReadLine().Split(';', StringSplitOptions.RemoveEmptyEntries);
            var productsInput = Console.ReadLine().Split(';', StringSplitOptions.RemoveEmptyEntries);

            for (int i = 0; i < personsInput.Length; i++)
            {
                var args = personsInput[i].Split('=', StringSplitOptions.RemoveEmptyEntries);
                var person = new Person(args[0], decimal.Parse(args[1]));
                persons.Add(person);
            }

            for (int i = 0; i < productsInput.Length; i++)
            {
                var args = productsInput[i].Split('=', StringSplitOptions.RemoveEmptyEntries);
                var product = new Product(args[0], decimal.Parse(args[1]));
                products.Add(product);
            }
        }

    }
}
