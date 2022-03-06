using Telephony.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Telephony.Core
{
    public class Engine
    {
        private Smartphone smartphone;
        private IList<string> numbers;
        private IList<string> urls;

        public Engine()
        {
            this.smartphone = new Smartphone();
            this.numbers = new List<string>();
            this.urls = new List<string>();
        }

        public void Run()
        {
            this.numbers = Console.ReadLine().Split().ToList();
            this.urls = Console.ReadLine().Split().ToList();

            CallPhoneNumber();
            BrowseURL();
        }

        private void BrowseURL()
        {

            foreach (var url in this.urls)
            {
                try
                {

                    {
                        Console.WriteLine(this.smartphone.Browse(url));
                    }
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }

        private void CallPhoneNumber()
        {
            foreach (var number in this.numbers)
            {
                try
                {

                    Console.WriteLine(this.smartphone.Call(number));

                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }
    }
}
