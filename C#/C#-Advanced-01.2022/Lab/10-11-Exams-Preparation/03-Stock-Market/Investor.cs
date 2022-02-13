using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StockMarket
{
    public class Investor
    {
        private List<Stock> stocks;
        public Investor(string fullName, string emailAddress, decimal moneyToInvest,string brokerName)
        {
            this.FullName = fullName;
            this.EmailAddress = emailAddress;
            this.MoneyToInwest = moneyToInvest;
            this.BrokerName = brokerName;
            this.stocks = new List<Stock>();
        }

        public IReadOnlyCollection<Stock> Stocks=>this.stocks;
        public string FullName { get; set; }
        public string EmailAddress { get; set; }
        public decimal MoneyToInwest { get; set; }
        public string BrokerName { get; set; }
        public int Count => this.stocks.Count;
        public void BuyStock(Stock stock)
        {
            if (!this.stocks.Any(x=>x.CompanyName==stock.CompanyName)&&stock.MarketCapitalization>10000 && this.MoneyToInwest>=stock.PricePerShare)
            {
                this.MoneyToInwest -= stock.PricePerShare;
                this.stocks.Add(stock);
            }
        }
        public string SellStock(string companyName, decimal sellPrice)
        {
            if (!this.stocks.Any(x=>x.CompanyName==companyName))
            {
                return $"{companyName} does not exist.";
            }
            else if (this.stocks.Any(x=>x.CompanyName==companyName&&x.PricePerShare<sellPrice))
            {
                return $"Cannot sell {companyName}.";
            }
            else
            {
                this.stocks.Remove(this.stocks.FirstOrDefault(x=>x.CompanyName==companyName));
                this.MoneyToInwest+=sellPrice;
                return $"{companyName} was sold.";
            }
        }
        public Stock FindStock(string companyName)
        {
            return this.stocks.Any(x => x.CompanyName == companyName) ? this.stocks.FirstOrDefault(x => x.CompanyName == companyName) : null;
        }
        public Stock FindBiggestCompany()
        {
            return this.stocks.Any() ? this.stocks.OrderByDescending(x => x.MarketCapitalization).FirstOrDefault() : null;
        }
        public string InvestorInformation()
        {
            var sb = new StringBuilder();
            sb.AppendLine($"The investor {this.FullName} with a broker {this.BrokerName} has stocks:");
            foreach (var stock in this.stocks)
            {
                sb.AppendLine(stock.ToString());
            }
            return sb.ToString().Trim();
        }
    }
}
