using System;
using System.Collections.Generic;
using System.Text;

namespace P03.Detail_Printer_After
{
    public interface IPrint
    {
        public IList<IEmployee> Employees { get; }
        public void PrintDetails();
    }
}
