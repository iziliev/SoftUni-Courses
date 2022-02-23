using System;
using System.Collections.Generic;

namespace CustomStack
{
    public class StartUp
    {
        public static void Main()
        {
            var myStack = new StackOfStrings();

            myStack.AddRange(new[] { "1", "2", "3", "4", "5" });
            myStack.AddRange(new List<string>() { "Pesho", "Gosho", "Ivo", "Niki", });

            Console.WriteLine(string.Join(", ",myStack));
        }
    }
}
