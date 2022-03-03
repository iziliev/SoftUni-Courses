
using _03_Telephony.Contracts;
using _03_Telephony.Exeptions;
using System;
using System.Linq;
using System.Text;

namespace _03_Telephony.Models
{
    public class Phone : ICallable,IBrowseble
    {
        public string Browse(string URL)
        {
            if (URL.Any(char.IsNumber))
            {
                throw new ArgumentException(ExeptionsMessages.urlEx);
            }

            return $"Browsing: {URL}!";
        }

        public string Call(string number)
        {
            if (number.Any(char.IsLetter))
            {
                throw new ArgumentException(ExeptionsMessages.numberEx);
            }

            return number.Length == 10 ? $"Calling... {number}" : $"Dialing... {number}";
        }
    }
}
