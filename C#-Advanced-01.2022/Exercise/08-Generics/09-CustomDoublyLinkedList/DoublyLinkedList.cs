using System;

namespace CustomDoublyLinkedList
{
    public class DoublyLinkedList<T>
    {
        private Node<T> first;

        private Node<T> last;

        public int Count { get; private set; }

        public void AddFirst(T element)
        {
            Node<T> newHead = new Node<T>(element);

            if (Count == 0)
            {
                first = last = newHead;
            }
            else
            {
                newHead.Next = first;
                first.Previous = newHead;
                first = newHead;
            }
            Count++;
        }

        public void AddLast(T element)
        {
            Node<T> newTail = new Node<T>(element);

            if (Count == 0)
            {
                first = last = newTail;
            }
            else
            {
                newTail.Previous = last;
                last.Next = newTail;
                last = newTail;
            }
            Count++;
        }

        public T RemoveFirst()
        {
            if (Count == 0)
            {
                throw new InvalidOperationException("The list is empty");
            }

            var firstElement = first.Value;

            first = first.Next;

            if (first != null)
            {
                first.Previous = null;
            }
            else
            {
                last = null;
            }
            Count--;

            return firstElement;
        }

        public T RemoveLast()
        {
            if (Count == 0)
            {
                throw new InvalidOperationException("The list is empty");
            }

            var lastElement = last.Value;

            last = last.Previous;

            if (last != null)
            {
                last.Next = null;
            }
            else
            {
                first = null;
            }
            Count--;

            return lastElement;
        }

        public void ForEach(Action<T> action)
        {
            var current = first;

            while (current != null)
            {
                action(current.Value);
                current = current.Next;
            }
        }

        public T[] ToArray()
        {
            T[] array = new T[Count];
            var node = first;

            for (int i = 0; i < Count; i++)
            {
                array[i] = node.Value;
                node = node.Next;
            }

            return array;
        }
    }
}