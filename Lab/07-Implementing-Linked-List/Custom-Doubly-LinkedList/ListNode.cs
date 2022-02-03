using System;
using System.Collections.Generic;
using System.Text;

namespace CustomDoublyLinkedList
{
    public class ListNode
    {
        public ListNode(int value)
        {
            this.Value = value;
        }
        public ListNode Next { get; set; }
        public ListNode Previos { get; set; }
        public int Value { get; set; }
    }
}
