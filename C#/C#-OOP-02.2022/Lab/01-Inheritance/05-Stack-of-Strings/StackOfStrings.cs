﻿using System.Collections.Generic;

namespace CustomStack
{
    public class StackOfStrings:Stack<string>
    {
        public bool IsEmpty()
        {
            return this.IsEmpty();
        }
        public Stack<string> AddRange(IEnumerable<string> items)
        {
            foreach (var item in items)
            {
                this.Push(item);
            }
            return this;
        }
    }
}
