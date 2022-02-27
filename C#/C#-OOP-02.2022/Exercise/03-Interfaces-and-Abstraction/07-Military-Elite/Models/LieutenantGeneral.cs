using _07_Military_Elite.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace _07_Military_Elite.Models
{
    public class LieutenantGeneral : Private, ILieutenantGeneral
    {
        public LieutenantGeneral(int id, string firstName, string lastname, decimal salary) 
            : base(id, firstName, lastname, salary)
        {
            this.Privates = new List<IPrivate>();
        }

        public List<IPrivate> Privates { get; }

        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.AppendLine(base.ToString());
            sb.AppendLine("Privates:");
            foreach (var item in this.Privates)
            {
                sb.AppendLine($"  {item}");
            }
            return sb.ToString().Trim();
        }
    }
}
