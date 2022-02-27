using System;
using System.Collections.Generic;
using System.Text;

namespace _03_Telephony.Contracts
{
    public interface IPhonable
    {
        public void Call(string phoneNumber);
    }
}
