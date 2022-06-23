using System;
using System.Collections.Generic;
using System.Text;

namespace P03.Detail_Printer_After
{
    public class Manager : Employee
    {
        public Manager(string name, ICollection<string> documents) 
            : base(name)
        {
            this.Documents = new List<string>(documents);
        }

        public IReadOnlyCollection<string> Documents { get; set; }

        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.AppendLine(base.ToString());
            sb.AppendLine(string.Join(Environment.NewLine, this.Documents));
            return sb.ToString().Trim();
        }
    }
}
