using _08_Collection_Hierarchy.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace _08_Collection_Hierarchy.Models
{
    public class AddCollection : IAddCollection
    {
        public AddCollection()
        {
            this.Items = new LinkedList<string>();
        }
        public LinkedList<string> Items { get; }
        
        public int Add(string items)
        {
            var currentIndex = this.Items.Count;
            this.Items.AddLast(items);
            return currentIndex;
        }
    }
}
