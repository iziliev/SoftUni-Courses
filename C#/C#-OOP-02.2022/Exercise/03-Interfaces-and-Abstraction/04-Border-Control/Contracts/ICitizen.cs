namespace _04_Border_Control.Contracts
{
    public interface ICitizen:IIdentifiable
    {
        public string Name { get; }
        public int Age { get; }
    }
}
