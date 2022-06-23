namespace P11_String_Concatenation
{
    using System;
    class String_Concatenation
    {
        static void Main()
        {
            char simbol = char.Parse(Console.ReadLine());
            string command = Console.ReadLine();
            int n = int.Parse(Console.ReadLine());
            string output = string.Empty;

            for (int i = 1; i <= n; i++)
            {
                string word = Console.ReadLine();

                if (command == "even")
                {
                    if (i % 2 == 0)
                    {
                        output += word + simbol;
                    }
                }
                if (command == "odd")
                {
                    if (i % 2 != 0)
                    {
                        output += word + simbol;
                    }
                }
            }
            var result = output.Remove(output.Length-1);
            Console.WriteLine(result);
        }
    }
}
