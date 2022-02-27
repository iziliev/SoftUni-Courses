using System;
using System.Collections.Generic;
using System.Text;

namespace _03_Telephony.Contracts
{
    public interface ISmatphonable :IPhonable
    {
        public void Browsing(string url);
    }
}
