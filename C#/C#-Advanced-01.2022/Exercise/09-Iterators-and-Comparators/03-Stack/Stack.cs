using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Stack
{
    public class Stack<T> : IEnumerable<T>
    {
        private List<T> list;
        private int index;

        public Stack()
        {
            this.list = new List<T>();
            this.index = -1;
        }

        public void Push(T items)
        {
            this.list.Add(items);
            index++;
        }

        public void Pop()
        {
            if (!this.list.Any())
            {
                throw new InvalidOperationException("No elements");
            }
            this.list.RemoveAt(this.index);
            this.index--;
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = this.list.Count - 1; i >= 0; i--)
            {
                yield return this.list[i];
            }
            for (int i = this.list.Count - 1; i >= 0; i--)
            {
                yield return this.list[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}
