namespace _06_Food_Shortage.Contracts
{
    public interface IRebel:IIdentifiable,IBuyer
    {
        public string Group { get; }
    }
}
