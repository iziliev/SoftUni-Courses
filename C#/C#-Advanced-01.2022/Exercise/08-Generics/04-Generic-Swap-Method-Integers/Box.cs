using System;
using System.Collections.Generic;
using System.Text;

namespace GenericSwapMethodIntegers
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
        public void Swap(int firstIndex, int secondIndex)
        {
            if (IsInRange(firstIndex)&&IsInRange(secondIndex))
            {
                var tempItem = this.items[firstIndex];
                this.items[firstIndex] = this.items[secondIndex];
                this.items[secondIndex] = tempItem;
            }
            else
            {
                throw new IndexOutOfRangeException();
            }
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
        private bool IsInRange(int firstIndex)
        {
            return firstIndex>=0&&firstIndex<this.items.Count;
        }

    }
}
