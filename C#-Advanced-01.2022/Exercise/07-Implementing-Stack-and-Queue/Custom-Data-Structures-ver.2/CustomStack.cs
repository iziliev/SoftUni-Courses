using System;
using System.Collections.Generic;
using System.Text;

namespace CustomDataStructures
{
    public class CustomStack
    {
        private const int InitialCapacity = 2;

        private int[] items = new int[InitialCapacity];
        public CustomStack()
        {
            this.items=new int[InitialCapacity];
        }
        //•	void Push(int element) – Adds the given element to the stack
        //•	int Pop() – Removes the last added element
        //•	int Peek() – Returns the last element in the stack without removing it
        //•	void ForEach(Action<int> action)
        
        public int Count { get;private set; }
        public void Push(int element)
        {
            if (Count==this.items.Length)
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
        public int Pop()
        {
            if (Count==0)
            {
                throw new InvalidOperationException("CustomStack is empty")
            }

            var element = this.items[Count];
            this.items[Count] = 0;
            Count--;

            if (Count<=this.items.Length/4)
            {
                var newArr = new int[this.items.Length / 2];

                for (int i = 0; i < Count; i++)
                {
                    newArr[i] = this.items[i];
                }
                this.items = newArr;
            }

            return element;
        }
        public int Peek()
        {
            return this.items[Count];
        }
        public void ForEach(Action<int> action)
        {
            for (int i = 0; i < Count; i++)
            {
                action(this.items[i]);
            }
        }
    }
}
