using System;
using System.Collections.Generic;
using System.Text;

namespace CustomDoublyLinkedList
{
    public class DoublyLinkedList
    {
        private ListNode first = null;
        private ListNode last = null;

        public int Count 
        { 
            get
            {
                var count = 0;
                var currentItem = first;
                while (currentItem != null)
                {
                    count++;
                    currentItem = currentItem.Next;
                }

                return count;
            } 
        }

        public void AddFirst(int element)
        {
            var newItem = new ListNode(element);

            if (first == null)
            {
                first = newItem;
                last = newItem;
            }
            else
            {
                newItem.Next = first;
                first.Previos = newItem;
                first = newItem;
            }
        }

        public void AddLast(int element)
        {
            var newItem = new ListNode(element);

            if (last == null)
            {
                first = newItem;
                last = newItem;
            }
            else
            {
                newItem.Previos = last;
                last.Next = newItem;
                last = newItem;
            }
        }

        public int RemoveFirst()
        {
            if (first == null)
            {
                throw new ArgumentNullException();
            }

            var currentItem = first;
            if (first == last)
            {
                first = null;
                last = null;
            }
            else
            {
                first = currentItem.Next;
                first.Previos = null;
            }
            return currentItem.Value;
        }

        public int RemoveLast()
        {
            if (last==null)
            {
                throw new ArgumentNullException();
            }

            var currentItem = last;
            if (first==last)
            {
                first = null;
                last = null;
            }
            else
            {
                last = currentItem.Previos;
                last.Next = null;
            }

            return currentItem.Value;
        }

        public  void ForEach(Action<int> action)
        {
            var currentItem = first;
            while (currentItem != null)
            {
                action(currentItem.Value);
                currentItem = currentItem.Next;
            }
        }

        public int[] ToArray()
        {
            var arr = new int[this.Count];

            var currentItem = first;
            var index = 0;

            while (currentItem!=null)
            {
                arr[index] = currentItem.Value;
                index++;
                currentItem = currentItem.Next;
            }

            return arr;
        }

        public string RemoveElement(int element)
        {
            if (this.Count==0)
            {
                throw new ArgumentNullException();
            }
            else if (this.Count==1)
            {
                var currentItem = first;
                while (currentItem != null)
                {
                    if (currentItem.Value == element)
                    {
                        
                        first = null;
                        last = null;
                        return $"{element} was deleted from collection!";

                    }

                    currentItem = currentItem.Next;
                }

                return $"{element} doesn't contains in collection!";
            }
            else
            {
                var currentItem = first;
                while (currentItem!=null)
                {
                    if (currentItem.Value==element)
                    {
                        currentItem.Previos.Next = currentItem.Next;
                        currentItem.Next.Previos = currentItem.Previos;
                        return $"{element} was deleted from collection!";
                    }

                    currentItem = currentItem.Next;
                }

                return $"{element} doesn't contains in collection!";
            }
        }
    }
}
