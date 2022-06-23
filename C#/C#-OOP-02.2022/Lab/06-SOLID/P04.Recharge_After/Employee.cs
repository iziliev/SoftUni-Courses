namespace P04.Recharge_After
{
    using System;

    public class Employee : Worker
    {
        public Employee(string id)
            : base(id)
        {
        }

        public override void Recharge()
        {
            throw new InvalidOperationException("Employee cannot recharge");
        }

        public override void Sleep()
        {
            // sleep...
        }

    }
}
