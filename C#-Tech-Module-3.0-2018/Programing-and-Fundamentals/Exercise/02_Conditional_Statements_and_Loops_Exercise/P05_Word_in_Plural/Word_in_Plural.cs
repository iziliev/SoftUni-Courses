namespace P05_Word_in_Plural
{
    using System;
    class Word_in_Plural
    {
        static void Main()
        {
            string input = Console.ReadLine();
            string inPlural = string.Empty;

            if (input.EndsWith("y"))
            {
                inPlural = input.Remove(input.Length - 1) + "ies";
            }
            else if (input.EndsWith("o") ||
                input.EndsWith("ch") ||
                input.EndsWith("s") ||
                input.EndsWith("sh") ||
                input.EndsWith("x") ||
                input.EndsWith("z"))
            {
                inPlural = input + "es";
            }
            else
            {
                inPlural = input + "s";
            }
            Console.WriteLine(inPlural);
        }
    }
}
