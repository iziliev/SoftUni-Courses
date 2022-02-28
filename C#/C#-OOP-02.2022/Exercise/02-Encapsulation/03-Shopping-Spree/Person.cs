using System;
using System.Collections.Generic;
using System.Text;

namespace _03_Shopping_Spree
{
    public class Person
    {
        private string name;
        private decimal money;
        private List<Product> products;
        public Person(string name, decimal money)
        {
            this.Name = name;
            this.Money = money;
            this.products = new List<Product>();
        }

        public string Name
        {
            get
            {
                return name;
            }
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Name cannot be empty");
                }
                name = value;
            }
        }
        public decimal Money
        {
            get
            {
                return money;
            }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Money cannot be negative");
                }
                money = value;
            }
        }

        public IReadOnlyCollection<Product> Products => this.products;

        public string BuyProduct(Product product)
        {
            if (this.Money - product.Cost >= 0)
            {
                this.Money-= product.Cost;
                this.products.Add(product);
                return $"{this.Name} bought {product.Name}";
            }
            return $"{this.Name} can't afford {product.Name}";
        }

        public override string ToString()
        {
            return this.Products.Count == 0 ? "Nothing bought" : string.Join(", ", this.products);
        }
    }
}
