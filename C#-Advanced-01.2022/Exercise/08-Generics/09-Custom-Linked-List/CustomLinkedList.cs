using System;
using System.Collections.Generic;
using System.Text;

namespace CustomLinkedList
{
    public class CustomLinkedList<T>
    {
        private const int DefaultLenght = 2;

        private T[] items;

        public CustomLinkedList()
        {
            this.items = new T[DefaultLenght];
        }
        public int Count { get; private set; }

        public T this[int index]
        {
            get
            {
                if (index>=this.Count)
                {
                    throw new ArgumentOutOfRangeException();
                }
                return this.items[index];
            }
            set
            {
                if (index >= this.Count)
                {
                    throw new ArgumentOutOfRangeException();
                }
                this.items[index]=value;
            }
        }
        public void Add(T item)
        {
            if (this.Count == this.items.Length)
            {
                Resize();
            }

            this.items[this.Count] = item;
            this.Count++;
        }
        public T RemoveAt(int index)
        {
            if (IsInRange(index))
            {
                var element = this.items[index];

                Shrink(index);

                return element;
            }
            else
            {
                throw new IndexOutOfRangeException();
            }
        }
        public T[] ToArray()
        {
            var array = new T[this.Count];
            for (int i = 0; i < this.Count; i++)
            {
                array[i] = this.items[i];
            }
            return array;
        }
        public void Insert(int index, T item)
        {
            if (this.Count == this.items.Length && IsInRange(index))
            {
                Resize();
            }
            this.Count++;

            for (int i = this.Count; i >= index; i--)
            {
                this.items[i] = this.items[i-1];
            }
            this.items[index]=item;
        }
        public bool Contains(T element)
        {
            for (int i = 0; i < this.Count; i++)
            {
                if (element.Equals(this.items[i]))
                {
                    return true;
                }
            }
            return false;
        }
        public void Swap(int firstIndex, int secondIndex)
        {
            if (IsInRange(firstIndex) && IsInRange(secondIndex))
            {
                var temp = this.items[firstIndex];
                this.items[firstIndex] = this.items[secondIndex];
                this.items[secondIndex] = temp;
            }
            else
            {
                throw new ArgumentOutOfRangeException();
            }
        }
        private void Resize()
        {
            var array = new T[this.items.Length * 2];

            for (int i = 0; i < this.items.Length; i++)
            {
                array[i] = this.items[i];
            }
            this.items = array;
        }
        private void Shrink(int index)
        {
            for (int i = index; i < this.Count-1; i++)
            {
                this.items[i] = this.items[i + 1];
            }
            this.Count--;

            if (this.Count < this.items.Length / 4)
            {
                var array = new T[this.items.Length / 2];

                for (int i = 0; i < this.items.Length; i++)
                {
                    array[i] = this.items[i];
                }
                this.items = array;
            }
        }
        private bool IsInRange(int index)
        {
            return index >= 0 && index < this.Count;
        }
    }
}
