using System;
using System.Collections.Generic;
using System.Text;

namespace CustomDataStructures
{
    public class CustomQueue
    {
        private const int initialCapacity = 4;

        private int[] items=new int[initialCapacity];
        public int Count { get; private set; }
        public void Enqueue(int element)
        {
            if (Count == this.items.Length)
            {
                var newArr = new int[this.items.Length * 2];

                for (int i = 0; i < items.Length; i++)
                {
                    newArr[i] = this.items[i];
                }
                this.items = newArr;
            }
            this.items[Count++] = element;
        }
        public int Dequeue()
        {
            if (Count==0)
            {
                throw new ArgumentOutOfRangeException();
            }

            var element = this.items[0];
            this.items[0] = 0;
            Count--;

            for (int i = 0; i < Count; i++)
            {
                this.items[i]=this.items[i+1];
            }

            if (Count<=this.items.Length/4)
            {
                var newArr = new int[this.items.Length / 2];

                for (int i = 0; i < Count; i++)
                {
                    newArr[i]=this.items[i];
                }
                this.items=newArr;
            }

            return element;
        }
        public int Peek()
        {
            if (Count==0)
            {
                throw new ArgumentOutOfRangeException();
            }
            return this.items[0];
        }
        public void Clear()
        {
            var tempArr = new int[initialCapacity];
            this.items = tempArr;
            Count = 0;
        }
        public void ForEach(Action<int> action)
        {
            for (int i = 0;i < Count; i++)
            {
                action(this.items[i]);
            }
        }

    }
}
