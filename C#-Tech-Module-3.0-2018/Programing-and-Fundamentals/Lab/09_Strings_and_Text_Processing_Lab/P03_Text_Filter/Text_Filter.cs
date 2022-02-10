using System;

namespace P03_Text_Filter
{
    class Text_Filter
    {
        static void Main()
        {
            string[] bannwords = Console.ReadLine()
                .Split(',',' ',StringSplitOptions.RemoveEmptyEntries);
            string text = Console.ReadLine();

            foreach (var item in bannwords)
            {
                if (text.Contains(item))
                {
                    text = text.Replace(item, new string('*', item.Length));
                }              
            }
            Console.WriteLine(text);
        }
    }
}
