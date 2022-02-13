using System;
using System.Collections.Generic;

namespace BoxOfT
{
    public class Box<T>
    {
        private List<T> items;

        public Box()
        {
            this.items = new List<T>();
        }

        public int Count
            => this.items.Count;

        public void Add(T element)
        {
            this.items.Add(element);
        }

        public T Remove()
        {
            if (this.Count < 0 && this.Count >= this.items.Count)
            {
                throw new IndexOutOfRangeException();
            }

            var element = this.items[Count - 1];
            this.items.RemoveAt(Count - 1);
            return element;
        }
    }
}