using System;
using System.Collections.Generic;
using System.Text;

namespace _08_Collection_Hierarchy.Contracts
{
    public interface IAddRemoveCollection:IAddCollection
    {
        public string Remove();
    }
}
