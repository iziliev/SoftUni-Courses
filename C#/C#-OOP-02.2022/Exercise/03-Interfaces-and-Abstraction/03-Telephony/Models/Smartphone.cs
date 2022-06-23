using Telephony.Contracts;
using Telephony.ExeptionMessages;
using System;
using System.Linq;

namespace Telephony.Models
{
    public class Smartphone : ICallable,IBrowseable
    {
        public string Browse(string URL)
        {
            if (URL.Any(char.IsDigit))
            {
                throw new ArgumentException(ExeptionsMessages.urlEx);
            }

            return $"Browsing: {URL}!";
        }

        public string Call(string number)
        {
            if (!number.All(char.IsDigit))
            {
                throw new ArgumentException(ExeptionsMessages.numberEx);
            }

            return number.Length > 7 ? $"Calling... {number}" : $"Dialing... {number}";
        }
    }
}
