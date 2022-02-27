using _03_Telephony.Contracts;
using _03_Telephony.Models;
using System;

namespace _03_Telephony
{
    public class StartUp
    {
        public static void Main()
        {
            var phoneNumbers = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
            var urls = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);

            for (int i = 0; i < phoneNumbers.Length; i++)
            {
                try
                {
                    if (phoneNumbers[i].Length == 7)
                    {
                        IPhonable phone = new StationaryPhone();
                        phone.Call(phoneNumbers[i]);
                    }
                    else
                    {
                        ISmatphonable phone = new SmartPhone();
                        phone.Call(phoneNumbers[i]);
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            
            for (int i = 0; i < urls.Length; i++)
            {
                try
                {
                    ISmatphonable phone = new SmartPhone();
                    phone.Browsing(urls[i]);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }
    }
}
