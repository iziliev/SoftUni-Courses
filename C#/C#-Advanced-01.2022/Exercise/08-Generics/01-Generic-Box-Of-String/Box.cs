using System;
using System.Collections.Generic;
using System.Text;

namespace GenericBoxOfString
{
    public class Box<T>
    {
        private List<T> items;
        public Box()
        {
            this.items = new List<T>();
        }

        public void Add(T item)
        {
            this.items.Add(item);
        }
        public override string ToString()
        {
            var sb = new StringBuilder();
            
            foreach (var item in this.items)
            {
                sb.AppendLine($"{typeof(T)}: {item}");
            }

            return sb.ToString().Trim();
        }
    }
}
