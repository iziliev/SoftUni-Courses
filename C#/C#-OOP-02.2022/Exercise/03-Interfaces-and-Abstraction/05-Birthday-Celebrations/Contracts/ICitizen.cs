namespace _05_Birthday_Celebrations.Contracts
{
    public interface ICitizen:IIdentifiable,IBirthdable
    {
        public string Name { get; }
        public int Age { get; }
    }
}
