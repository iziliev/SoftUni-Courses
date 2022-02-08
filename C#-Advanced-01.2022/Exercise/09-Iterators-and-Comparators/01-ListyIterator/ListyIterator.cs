using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ListyIterator
{
    public class ListyIterator<T>
    {
        private List<T> list;
        private int index;
        public ListyIterator(List<T> list)
        {
            this.list = list;
            this.index = 0;
        }
        public bool Move()
        {
            var isInRange = HasNext();

            if (isInRange)
            {
                index++;
            }
            return isInRange;
        }
        public void Print()
        {
            
            if (!this.list.Any())
            {
                throw new InvalidOperationException("Invalid Operation!");
            }
            else
            {
                Console.WriteLine(this.list[index]);
            }
        }
        public bool HasNext()
        {
            var isInRange = index+1 < list.Count;

            if (isInRange)
            {
                return true;
            }
            return false;
        }
    }
}
