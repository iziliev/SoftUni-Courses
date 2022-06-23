using System;
using System.Collections.Generic;
using System.Text;

namespace P04.Recharge_After
{
    public interface IWorker
    {
        public string Id { get; }
        public int WorkingHours { get; }
    }
}
