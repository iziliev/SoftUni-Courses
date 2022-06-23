using _08_Collection_Hierarchy.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace _08_Collection_Hierarchy.Models
{
    public class AddRemoveCollection : AddCollection, IAddRemoveCollection
    {
        public AddRemoveCollection()
            :base()
        {
        }

        public int Add(string items)
        {
            this.Items.AddFirst(items);
            return 0;
        }

        public string Remove()
        {
            var item = this.Items.Last.Value;
            if (item!=null)
            {
                this.Items.RemoveLast();
            }
            return item;
        }
    }
}
