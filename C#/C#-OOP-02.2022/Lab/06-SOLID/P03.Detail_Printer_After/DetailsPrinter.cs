using System;
using System.Collections.Generic;
using System.Text;

namespace P03.Detail_Printer_After
{
    public class DetailsPrinter:IPrint
    {
        private IList<IEmployee> employees;

        public DetailsPrinter(IList<IEmployee> employees)
        {
            this.Employees = employees;
        }

        public IList<IEmployee> Employees { get; private set; }

        public void PrintDetails()
        {
            foreach (var employee in this.Employees)
            {
                Console.WriteLine(employee);
            }
        }

    }
}
