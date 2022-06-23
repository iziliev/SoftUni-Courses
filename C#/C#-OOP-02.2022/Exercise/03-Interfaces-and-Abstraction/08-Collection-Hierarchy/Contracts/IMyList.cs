using System;
using System.Collections.Generic;
using System.Text;

namespace _08_Collection_Hierarchy.Contracts
{
    public interface IMyList:IAddRemoveCollection
    {
        public int Used();
    }
}
