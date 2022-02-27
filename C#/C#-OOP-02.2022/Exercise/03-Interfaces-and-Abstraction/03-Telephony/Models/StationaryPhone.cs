using _03_Telephony.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _03_Telephony.Models
{
    public class StationaryPhone : IPhonable
    {
        public void Call(string phoneNumber)
        {
            if (!phoneNumber.Any(char.IsDigit))
            {
                throw new ArgumentException("Invalid number!");
            }
            Console.WriteLine($"Dialing... {phoneNumber}");
        }
    }
}
