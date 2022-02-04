using System;
using System.Collections.Generic;
using System.Text;

namespace GenericCountMethodStrings
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
        public int CompareBoxItems(string item)
        {
            var count = 0;
            
            foreach (var items in this.items)
            {
                if (items.CompareTo(item) > 0)
                {
                    count++;
                }
            }
            return count;
        }
    }
}
