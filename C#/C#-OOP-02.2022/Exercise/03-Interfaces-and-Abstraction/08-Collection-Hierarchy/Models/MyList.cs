using _08_Collection_Hierarchy.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace _08_Collection_Hierarchy.Models
{
    public class MyList : AddCollection, IMyList
    {
        public MyList():base()
        {
        }

        public int Add(string items)
        {
            this.Items.AddFirst(items);
            return 0;
        }

        public string Remove()
        {
            var item = this.Items.First.Value;

            if (item!=null)
            {
                this.Items.RemoveFirst();
            }

            return item;
            
        }

        public int Used()
        {
            return this.Items.Count;
        }

    }
}
