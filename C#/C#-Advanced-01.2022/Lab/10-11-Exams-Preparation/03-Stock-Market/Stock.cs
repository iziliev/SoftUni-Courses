using System.Text;

namespace StockMarket
{
    public class Stock
    {
        public Stock(string companyName,string director, decimal pricePerShare, int totalNumberOfShare)
        {
            this.CompanyName = companyName;
            this.Director = director;
            this.PricePerShare = pricePerShare;
            this.TotalNumberOfShare = totalNumberOfShare;
            this.MarketCapitalization = pricePerShare * totalNumberOfShare;
        }
        public string CompanyName { get; set; }
        public string Director { get; set; }
        public decimal PricePerShare { get; set; }
        public int TotalNumberOfShare { get; set; }
        public decimal MarketCapitalization { get; private set; }
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.AppendLine($"Company: {this.CompanyName}");
            sb.AppendLine($"Director: {this.Director}");
            sb.AppendLine($"Price per share: ${this.PricePerShare}");
            sb.AppendLine($"Market capitalization: ${this.MarketCapitalization}");
            return sb.ToString().Trim();
        }
    }
}
