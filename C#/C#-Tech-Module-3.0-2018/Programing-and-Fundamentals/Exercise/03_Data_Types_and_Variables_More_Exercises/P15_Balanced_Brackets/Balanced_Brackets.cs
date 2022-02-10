namespace P15_Balanced_Brackets
{
    using System;
    class Balanced_Brackets
    {
        static void Main()
        {
            //int n = int.Parse(Console.ReadLine());
            //int left = 0;
            //int right = 0;
            //
            //for (int i = 0; i < n; i++)
            //{
            //    string input = Console.ReadLine();
            //
            //    if (input == "(")
            //    {
            //        left++;
            //    }
            //    if (input== ")")
            //    {
            //        right++;
            //    }
            //}
            //if (left==right)
            //{
            //    Console.WriteLine("BALANCED");
            //}
            //else
            //{
            //    Console.WriteLine("UNBALANCED");
            //}

            int numberOfInputs = int.Parse(Console.ReadLine());

            string lastBracket = string.Empty;
            string balance = "BALANCED";

            for (int i = 0; i < numberOfInputs; i++)
            {
                string currentInput = Console.ReadLine();
                if (currentInput == "(")
                {
                    if (lastBracket == "(")
                    {
                        balance = "UNBALANCED";
                        break;
                    }
                    lastBracket = "(";
                }
                if (currentInput == ")")
                {
                    if (lastBracket != "(")
                    {
                        balance = "UNBALANCED";
                        break;
                    }
                    lastBracket = ")";
                }
            }
            if (lastBracket == "(")
            {
                balance = "UNBALANCED";
            }

            Console.WriteLine(balance);
        }
    }
}
