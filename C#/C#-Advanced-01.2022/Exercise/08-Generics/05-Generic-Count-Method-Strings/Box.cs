using System;
using System.Collections.Generic;
using System.Text;

namespace GenericCountMethodStrings
{
    public class Box<T>
        where T :IComparable<T>
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
        public int CompareBoxItems(T item)
        {
            var count = 0;
            
            foreach (var items in this.items)
            {
                if (items.CompareTo(item)>0)
                {
                    count++;
                }
            }
            return count;
        }
    }
}
