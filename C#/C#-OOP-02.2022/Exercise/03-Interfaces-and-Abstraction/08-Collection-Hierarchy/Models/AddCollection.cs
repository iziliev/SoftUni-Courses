using _08_Collection_Hierarchy.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace _08_Collection_Hierarchy.Models
{
    public class AddCollection : List<string>, IAddCollection
    {
        public AddCollection()
        {
            this.Items = new List<string>();
        }

        public List<string> Items { get; private set; }
        public int AddItems(string item)
        {
            this.Items.Add(item);
            return this.Items.Count-1;
        }
    }
}
