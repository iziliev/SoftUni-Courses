using System;
using System.Collections.Generic;
using System.Text;

namespace P04.Recharge_After
{
    public class Robot : Worker
    {
        private int capacity;
        private int currentPower;

        public Robot(string id, int capacity) 
            : base(id)
        {
            this.capacity = capacity;
            this.CurrentPower = capacity;
        }

        public int Capacity
        {
            get { return this.capacity; }
        }

        public int CurrentPower
        {
            get { return this.currentPower; }
            set { this.currentPower = value; }
        }

        public override void Work(int hours)
        {
            if (hours > this.CurrentPower)
            {
                hours = CurrentPower;
            }
            base.Work(hours);
            this.CurrentPower -= hours;
        }

        public override void Recharge()
        {
            this.currentPower = this.capacity;
        }

        public override void Sleep()
        {
            throw new InvalidOperationException("Robots cannot sleep");
        }
    }
}