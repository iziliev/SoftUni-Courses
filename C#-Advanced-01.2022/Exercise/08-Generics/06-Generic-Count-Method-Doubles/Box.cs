using System;
using System.Collections.Generic;
using System.Text;

namespace GenericCountMethodDoubles
{
    public class Box
    {
        private List<double> items;
        public Box()
        {
            this.items = new List<double>();
        }

        public void Add(double item)
        {
            this.items.Add(item);
        }
        public int CompareBoxItems(double item)
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
