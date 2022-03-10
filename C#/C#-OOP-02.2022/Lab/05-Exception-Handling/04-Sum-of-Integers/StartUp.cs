using System;
using System.Collections.Generic;
using System.Linq;

namespace _04_Sum_of_Integers
{
    public class StartUp
    {
        public static void Main()
        {
            var items = new List<IElement>();

            var elements = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);

            for (int i = 0; i < elements.Length; i++)
            {
                try
                {
                    items.Add(new Element(elements[i]));
                }
                catch (FormatException ex)
                {
                    Console.WriteLine(ex.Message);
                }
                catch (OverflowException ex)
                {
                    Console.WriteLine(ex.Message);
                }
                finally
                {
                    Console.WriteLine($"Element '{elements[i]}' processed - current sum: {items.Sum(x=>int.Parse(x.Item))}");
                }
            }

            Console.WriteLine($"The total sum of all integers is: {items.Sum(x=>int.Parse(x.Item))}");
        }
    }
}
