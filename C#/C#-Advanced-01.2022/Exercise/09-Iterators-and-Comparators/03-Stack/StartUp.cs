using System;
using System.Linq;

namespace Stack
{
    public class StartUp
    {
        public static void Main()
        {
            var input = string.Empty;
            var stack = new Stack<int>();

            while ((input = Console.ReadLine()) != "END")
            {
                if (input.Contains("Push"))
                {
                    var data = input
                        .Split(new char[] { ' ', ','}, StringSplitOptions.RemoveEmptyEntries)
                        .Skip(1)
                        .Select(int.Parse)
                        .ToArray();

                    for (int i = 0; i < data.Length; i++)
                    {
                        stack.Push(data[i]);
                    }
                }
                else
                {
                    try
                    {
                        stack.Pop();
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                }
            }

            foreach (var item in stack)
            {
                Console.WriteLine(item);
            }
            
        }
    }
}
