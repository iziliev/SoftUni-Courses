namespace P17_Print_Part_of_the_ASCII_Table
{
    using System;
    class Print_Part_of_the_ASCII_Table
    {
        static void Main()
        {
            int start = int.Parse(Console.ReadLine());
            int finish = int.Parse(Console.ReadLine());

            for (int i = start; i <= finish; i++)
            {
                char letter = Convert.ToChar(i);
                Console.Write(letter + " ");
            }
            Console.WriteLine();
        }
    }
}
