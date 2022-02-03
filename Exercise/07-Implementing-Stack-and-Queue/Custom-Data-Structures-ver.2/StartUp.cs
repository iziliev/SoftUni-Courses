using System;

namespace CustomDataStructures
{
    public class StartUp
    {
        public static void Main()
        {
            var customList = new CustomList();

            customList.Add(1);
            customList.Add(2);
            customList.Add(3);
            customList.Add(4);
            customList.Add(5); 
            customList.Add(6);
            //1-2-3-5-6
            customList.RemoveAt(3);
            Console.WriteLine(customList.Contains(80));
            Console.WriteLine(customList.Contains(5));
            customList.Swap(0, 4);

            //6-2-3-5-1

            for (int i = 0; i < customList.Count; i++)
            {
                Console.WriteLine(customList[i]);
            }
            //6-2-11-3-5-1
            customList.Insert(2, 11);
            
            ;
        }
    }
}
