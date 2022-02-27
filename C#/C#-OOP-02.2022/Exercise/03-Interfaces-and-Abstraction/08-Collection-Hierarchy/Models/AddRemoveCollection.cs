using _08_Collection_Hierarchy.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace _08_Collection_Hierarchy.Models
{
    public class AddRemoveCollection : List<string>,IAddRemoveCollection
    {
        public AddRemoveCollection()
        {
            Collections = new List<string>();
        }

        public List<string> Collections { get;}
        public int AddItems(string item)
        {
            this.Collections.Insert(0, item);
            return 0;
        }

        public string RemoveItem()
        {
            var lastElement = this.Collections[this.Collections.Count - 1];
            this.Collections.Remove(lastElement);
            return lastElement;
        }
    }
}
