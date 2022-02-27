using _08_Collection_Hierarchy.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace _08_Collection_Hierarchy.Models
{
    public class MyList : List<string>,IMyList
    {
        
        public MyList()
        {
            Collections = new List<string>();
        }
        public int Count =>this.Collections.Count;

        public List<string> Collections { get; }
       
        public int AddItems(string item)
        {
            this.Collections.Insert(0, item);
            return 0;
        }

        public string RemoveItem()
        {
            var element = this.Collections[0];
            this.Collections.RemoveAt(0);
            return element;
        }
    }
}
