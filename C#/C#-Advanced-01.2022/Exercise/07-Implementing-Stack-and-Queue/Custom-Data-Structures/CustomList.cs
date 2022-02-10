using System;
using System.Collections.Generic;
using System.Text;

namespace CustomDataStructures
{
    class CustomList
    {
        private Item first=null;
        private Item last=null;

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
        public void Add(int element)
        {
            var newItem = new Item(element);
            if (first == null)
            {
                first = newItem;
                last = newItem;
            }

            else
            {
                last.Next = newItem;
                newItem.Pevious = last;
                last = newItem;
            }
        }

        public int RemoveAt(int index)
        {
            if (first == null)
            {
                throw new ArgumentException();
            }

            if (index >= this.Count || index < 0)
            {
                throw new ArgumentOutOfRangeException();
            }

            var currentItem = first;
            var count = 0;

            while (currentItem != null)
            {
                if (count == index)
                {
                    currentItem.Pevious.Next = currentItem.Next;
                    break;
                }
                count++;
                currentItem = currentItem.Next;
            }

            return currentItem.Value;
        }

        public bool Contains(int element)
        {
            var currentItem = first;

            while (currentItem!=null)
            {
                if (currentItem.Value==element)
                {
                    return true;
                }
                currentItem = currentItem.Next;
            }

            return false;
        }

        public void Swap(int firstIndex, int secondIndex)
        {
            if (this.Count<=2)
            {
                throw new ArgumentNullException();
            }

            if (firstIndex>=0 && firstIndex<this.Count && secondIndex>=0&&secondIndex<this.Count)
            {
                var currentItem = first;
                var arr = new int[this.Count];
                var index = 0;
                
                while (currentItem!=null)
                {
                    arr[index] = currentItem.Value;
                    index++;
                    currentItem = currentItem.Next;
                }

                first = null;
                last = null;

                var temp = arr[firstIndex];
                arr[firstIndex] = arr[secondIndex];
                arr[secondIndex] = temp;

                for (int i = 0; i < arr.Length; i++)
                {
                    Add(arr[i]);
                }
            }
        }

        public int[] ToArray()
        {
            var tempArr = new int[this.Count];
            var currentItem = first;
            var index = 0;
            while (currentItem !=null)
            {
                tempArr[index] = currentItem.Value;
                index++;
                currentItem = currentItem.Next;
            }
            return tempArr;
        }
    }
}
