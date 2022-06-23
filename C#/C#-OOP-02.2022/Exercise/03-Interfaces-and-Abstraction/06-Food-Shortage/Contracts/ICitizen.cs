namespace _06_Food_Shortage.Contracts
{
    public interface ICitizen: IIdentifiable
    {
        public string Id { get; }
        public string BirthDate { get; }
    }
}
