using System;
using System.Linq;

namespace ListyIterator
{
    public class StartUp
    {
        static void Main()
        {
            var input = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Skip(1)
                .ToList();

            var list = new ListyIterator<string>(input);

            var command = string.Empty;

            while ((command = Console.ReadLine()) != "END")
            {
                if (command == "Print")
                {
                    try
                    {
                        list.Print();
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                }
                else if (command == "HasNext")
                {
                    Console.WriteLine(list.HasNext());
                }
                else if (command == "Move")
                {
                    Console.WriteLine(list.Move());
                }
                else if (command == "PrintAll")
                {
                    Console.WriteLine(String.Join(" ", list));
                }
            }        
        }
    }
}
