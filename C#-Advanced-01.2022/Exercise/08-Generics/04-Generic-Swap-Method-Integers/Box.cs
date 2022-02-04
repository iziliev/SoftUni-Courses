using System;
using System.Collections.Generic;
using System.Text;

namespace GenericSwapMethodIntegers
{
    public class Box
    {
        private List<int> items;
        public Box()
        {
            this.items = new List<int>();
        }

        public void Add(int item)
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
            for (int i = 0; i < this.items.Count; i++)
            {
                var currentItem = this.items[i];
                sb.AppendLine($"{currentItem.GetType()} {currentItem}");
            }

            return sb.ToString().Trim();
        }
        private bool IsInRange(int firstIndex)
        {
            return firstIndex>=0&&firstIndex<this.items.Count;
        }

    }
}
