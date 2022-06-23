using System;
using System.Collections.Generic;
using System.Text;

namespace CustomDataStructures
{
    public class CustomStack
    {
        private Item first=null;

        public int Count
        {
            get
            {
                var currentItem = first;
                var count = 0;
                while (currentItem!=null)
                {
                    count++;
                    currentItem = currentItem.Next;
                }

                return count;
            }
        }

        public void Push(int element)
        {
            var newItem = new Item(element);

            if (first == null)
            {
                first = newItem;
            }
            else
            {
                newItem.Next = first;
                first = newItem;
            }
        }

        public int Pop()
        {
            if (first == null)
            {
                throw new ArgumentNullException();
            }

            var currentItem = first;

            if (this.Count==1)
            {
                first = null;
            }
            else
            {
                first = currentItem.Next;
            }

            return currentItem.Value;
        }

        public int Peek()
        {
            if (first == null)
            {
                throw new ArgumentNullException();
            }
            else
            {
                return first.Value;
            }
        }

        public  void ForEach(Action<int> action)
        {
            if (first==null)
            {
                throw new ArgumentNullException();
            }
            else
            {
                var currentItem = first;
                while (currentItem!=null)
                {
                    action(currentItem.Value);
                    currentItem = currentItem.Next;
                }
            }
        }
    }
}
