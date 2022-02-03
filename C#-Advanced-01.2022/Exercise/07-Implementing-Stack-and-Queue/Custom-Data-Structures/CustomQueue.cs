using System;
using System.Collections.Generic;
using System.Text;

namespace CustomDataStructures
{
    public class CustomQueue
    {
        private Item last=null;
        private Item first = null;

        public int Count
        {
            get
            {
                var count = 0;
                var currentItem = last;
                while (currentItem!=null)
                {
                    count++;
                    currentItem = currentItem.Pevious;
                }
                return count;
            }
        }

        public void Enqueue(int element)
        {
            var newItem = new Item(element);
            if (last==null)
            {
                last = newItem;
                first = newItem;
            }
            else
            {
                last.Next = newItem;
                newItem.Pevious = last;
                last = newItem;
            }
        }

        public int Dequeue()
        {
            if (first==null)
            {
                throw new ArgumentNullException();
            }
            var currentItem = first;

            if (this.Count==1)
            {
                first = null;
                last = null;
            }
            else
            {
                last = currentItem.Next;
                last.Pevious = null;
            }

            return currentItem.Value;
        }

        public int Peek()
        {
            if (last==null)
            {
                throw new ArgumentNullException();
            }
            else
            {
                return first.Value;
            }
        }

        public void Clear()
        {
            last = null;
            first = null;
        }

        public void ForEach(Action<int> action)
        {
            if (last==null)
            {
                throw new ArgumentNullException();
            }

            var currentItem = first;

            while (currentItem!=null)
            {
                action(currentItem.Value);
                currentItem = currentItem.Next;
            }
        }
    }
}
