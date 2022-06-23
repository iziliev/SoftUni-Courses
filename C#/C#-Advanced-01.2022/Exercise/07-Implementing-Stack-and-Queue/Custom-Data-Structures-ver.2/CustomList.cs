using System;
using System.Collections.Generic;
using System.Text;

namespace CustomDataStructures
{
    public class CustomList
    {
        private const int InitialCapacity = 2;
        public CustomList()
        {
            this.items = new int[InitialCapacity];
        }
        private int[] items { get; set; }
        public int Count { get; private set; }
        public int this[int index]
        {
            get
            {
                if (index>=this.Count)
                {
                    throw new ArgumentOutOfRangeException();
                }
                return items[index];
            }
            set
            {
                if (index >= this.Count)
                {
                    throw new ArgumentOutOfRangeException();
                }
                items[index] = value;
            }
        }
        public void Add(int element)
        {
            if (Count==this.items.Length)
            {
                var newArr = new int[items.Length * 2];
                for (int i = 0; i < this.items.Length; i++)
                {
                    newArr[i] = this.items[i];
                }
                this.items = newArr;
            }
            this.items[Count++]=element;
        }
        public int RemoveAt(int index)
        {
            if (index>=0 && index < Count)
            {
                var element = this.items[index];
                this.items[index] = 0;

                for (int i = index; i < Count; i++)
                {
                    this.items[i] = this.items[i + 1];
                }

                Count--;

                if (this.Count <= this.items.Length / 4)
                {
                    var tempArr = new int[this.items.Length / 2];
                    for (int i = 0; i < Count; i++)
                    {
                        tempArr[i] = this.items[i];
                    }
                    this.items = tempArr;
                }

                return element;
            }
            else
            {
                throw new IndexOutOfRangeException();
            }
            
        }
        public bool Contains(int element)
        {
            for (int i = 0; i <Count; i++)
            {
                if (element == this.items[i])
                {
                    return true;
                }
            }
            return false;
        }
        public void Swap(int firstIndex, int secondIndex)
        {
            if (firstIndex>=0&&firstIndex<Count&&secondIndex>=0&&secondIndex<Count)
            {
                var temp = this.items[firstIndex];
                this.items[firstIndex]= this.items[secondIndex];
                this.items[secondIndex]= temp;
            }
        }
        public void Insert(int index, int item)
        {
            if (index>=0 && index<Count)
            {
                if (this.items.Length == Count)
                {
                    var newArr = new int[items.Length * 2];
                    for (int i = 0; i < this.items.Length; i++)
                    {
                        newArr[i] = this.items[i];
                    }
                    this.items = newArr;
                }
                for (int i = Count+1; i >= index; i--)
                {
                    this.items[i] = this.items[i - 1];
                }

                this.items[index] = item;
            }
            else
            {
                throw new ArgumentOutOfRangeException();
            }
        }
    }
}
