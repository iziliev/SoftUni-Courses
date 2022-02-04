using System;
using System.Collections.Generic;
using System.Text;

namespace GenericBoxOfString
{
    public class Box
    {
        private List<string> items;
        public Box()
        {
            this.items = new List<string>();
        }

        public void Add(string item)
        {
            this.items.Add(item);
        }
        public override string ToString()
        {
            var sb = new StringBuilder();
            for (int i = 0; i < this.items.Count; i++)
            {
                var currentItem = this.items[i];

                sb.AppendLine($"{currentItem.GetType()}: {currentItem}");
            }

            return sb.ToString().Trim();
        }
    }
}
