using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _04_Pizza_Calories
{
    public class Pizza
    {
        private string name;
        private Dough dough;
        private List<Topping> toppings;

        public Pizza(string name, Dough dough)
        {
            this.Name = name;
            this.dough = dough;
            this.toppings = new List<Topping>();
        }

        public string Name
        {
            get
            {
                return name;
            }
            private set
            {
                if (string.IsNullOrEmpty(value) || value.Length > 15)
                {
                    throw new ArgumentException("Pizza name should be between 1 and 15 symbols.");
                }
                name = value;
            }
        }
        public void AddTopping(Topping topping)
        {
            if (this.toppings.Count == 10)
            {
                throw new Exception("Number of toppings should be in range [0..10].");
            }
            else
            {
                this.toppings.Add(topping);
            }
        }

        public double Calories => this.dough.Calories + this.toppings.Sum(x => x.Calories);

        public override string ToString()
        {
            return $"{this.name} - {this.Calories:f2} Calories.";
        }
    }
}
