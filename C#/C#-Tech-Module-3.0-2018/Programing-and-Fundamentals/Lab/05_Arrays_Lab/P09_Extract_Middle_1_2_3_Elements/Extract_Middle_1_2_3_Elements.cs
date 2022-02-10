using System;
using System.Linq;

namespace P09_Extract_Middle_1_2_3_Elements
{
    class Extract_Middle_1_2_3_Elements
    {
        static void Main()
        {
            int[] array = Console.ReadLine()
                .Split(' ')
                .Select(int.Parse)
                .ToArray();
            int lenghtArray = array.Length;
            

            if (lenghtArray == 1)
            {
                Console.Write("{ ");
                Console.Write(String.Join("",array));
                Console.WriteLine(" }");
                return;
            }
            else if (lenghtArray % 2 == 0)
            {
                int take = 2;
                int[] outputArray = new int[take];
                int startIndex = (array.Length - take) / 2;
                int count = 0;
                for (int i = startIndex; i < startIndex + 2; i++)
                {
                    outputArray[count] = array[i];
                    count++;
                }
                Console.Write("{ ");
                Console.Write(String.Join(", ",outputArray));
                Console.WriteLine(" }");
                return;
            }
            else
            {
                int take = 3;
                int[] outputArray = new int[take];
                int startIndex = (array.Length - take) / 2;
                int count = 0;

                for (int i = startIndex; i < startIndex + 3; i++)
                {
                    outputArray[count] = array[i];
                    count++;
                }
                Console.Write("{ ");
                Console.Write(String.Join(", ", outputArray));
                Console.WriteLine(" }");
                return;
            }
        }
    }
}
