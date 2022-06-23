namespace P04.Recharge_After
{
    public abstract class Worker : IWorker, ISleeper, IRechargeable
    {

        public Worker(string id)
        {
            this.Id = id;
            this.WorkingHours = 0;
        }

        public string Id { get; private set; }

        public int WorkingHours { get; protected set; }

        public virtual void Work(int hours)
        {
            this.WorkingHours += hours;
        }

        public abstract void Sleep();

        public abstract void Recharge();
        
    }
}