using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace CustomLinkedList
{
    public class DoublyLinkedList<T>:IEnumerable<T>
        where T : IComparable<T>
    {
        private class ListNode
        {
            public ListNode(T value)
            {
                this.Value = value;
            }
            public T Value { get; set; }
            public ListNode Previous { get; set; }
            public ListNode Next { get; set; }
        }

        private ListNode head;
        private ListNode tail;

        public int Count { get; private set; }

        public void AddFirst(T value)
        {
            var newHead = new ListNode(value);
            if (this.Count==0)
            {
                head = newHead;
                tail = newHead;
            }
            else
            {
                newHead.Next = this.head;
                this.head.Previous = newHead;
                this.head = newHead;
            }
            this.Count++;
        }
        public void AddLast(T value)
        {
            var newTail = new ListNode(value);
            if (this.Count == 0)
            {
                head = newTail;
                tail = newTail;
            }
            else
            {
                newTail.Previous = this.tail;
                this.tail.Next = newTail;
                this.tail = newTail;
            }
            this.Count++;
        }
        public T RemoveFirst()
        {
            if (this.Count==0)
            {
                throw new InvalidOperationException("The list is empty");
            }
            var firstElement = this.head.Value;
            this.head = this.head.Next;

            if (this.head!=null)
            {
                this.head.Previous = null;
            }
            else
            {
                this.tail=null;
            }
            this.Count--;
            return firstElement;
        }
        public T RemoveLast()
        {
            if (this.Count == 0)
            {
                throw new InvalidOperationException("The list is empty");
            }
            var lastElement = this.tail.Value;
            this.tail = this.tail.Previous;

            if (this.tail != null)
            {
                this.tail.Next = null;
            }
            else
            {
                this.head = null;
            }
            this.Count--;
            return lastElement;
        }

        public void ForEach(Action<T> action)
        {
            var currentNode = this.head;
            while (currentNode != null)
            {
                action(currentNode.Value);
                currentNode = currentNode.Next;
            }
        }

        public T[] ToArray()
        {
            var array = new T[this.Count];
            var index = 0;
            var currentNode = this.head;
            while (currentNode!=null)
            {
                array[index] = currentNode.Value;
                currentNode = currentNode.Next;
                index++;
            }
            return array;
        }

        public IEnumerator<T> GetEnumerator()
        {
            var array = this.ToArray();
            foreach (var item in array)
            {
                yield return item;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}
