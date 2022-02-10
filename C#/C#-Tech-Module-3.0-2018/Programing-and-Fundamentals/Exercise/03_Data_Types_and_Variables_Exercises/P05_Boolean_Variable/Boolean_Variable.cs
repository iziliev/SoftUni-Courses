using System;

namespace P05_Boolean_Variable
{
    class Boolean_Variable
    {
        static void Main()
        {
            string input = Console.ReadLine();
            var result = Convert.ToBoolean(input);
            if (result==true)
            {
                Console.WriteLine("Yes");
            }
            else
            {
                Console.WriteLine("No");
            }
            
        }
    }
}
