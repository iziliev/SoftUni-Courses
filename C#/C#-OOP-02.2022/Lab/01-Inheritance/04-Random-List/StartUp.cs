using System;

namespace CustomRandomList
{
    public class StartUp
    {
        public static void Main()
        {
            var myCustomList = new RandomList();
            myCustomList.Add("1");
            myCustomList.Add("2");
            myCustomList.Add("3");
            myCustomList.Add("4");
            myCustomList.Add("5");
            Console.WriteLine(myCustomList.RandomString());
            Console.WriteLine(myCustomList.RandomString());
            Console.WriteLine(myCustomList.RandomString());
        }
    }
}
