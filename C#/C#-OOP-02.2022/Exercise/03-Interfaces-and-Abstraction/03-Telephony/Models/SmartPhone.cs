using _03_Telephony.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _03_Telephony.Models
{
    public class SmartPhone : ISmatphonable
    {
        public void Browsing(string url)
        {
            if (url.Any(char.IsDigit))
            {
                throw new ArgumentException("Invalid URL!");
            }
            Console.WriteLine($"Browsing: {url}!");
        }

        public void Call(string phoneNumber)
        {
            if (!phoneNumber.Any(char.IsDigit))
            {
                throw new ArgumentException("Invalid number!");
            }
            Console.WriteLine($"Calling... {phoneNumber}");
        }
    }
}
