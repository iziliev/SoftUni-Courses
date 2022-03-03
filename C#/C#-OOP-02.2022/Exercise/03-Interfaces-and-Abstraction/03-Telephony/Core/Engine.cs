using _03_Telephony.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _03_Telephony.Core
{
    public class Engine
    {
        private Phone phone;
        private List<string> numbers;
        private List<string> urls;

        public Engine()
        {
            this.phone = new Phone();
            this.numbers = new List<string>();
            this.urls = new List<string>(); 
        }

        public void Run()
        {
            numbers = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).ToList();
            urls = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).ToList();

            try
            {
                foreach (var number in numbers)
                {
                    Console.WriteLine(this.phone.Call(number));
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            try
            {
                foreach (var url in urls)
                {
                    Console.WriteLine(this.phone.Browse(url));              
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
