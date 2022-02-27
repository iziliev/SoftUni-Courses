using System;
using System.Collections.Generic;
using System.Text;

namespace _04_Pizza_Calories
{
    public class Topping
    {
        private const int toppingDefaultCalories = 2;

        private Dictionary<string, double> modifiers = new Dictionary<string, double>()
        {
            {"meat",1.2 },
            {"veggies",0.8 },
            {"cheese",1.1 },
            {"sauce",0.9 }
        };

        private string toppingType;
        private int weight;

        public Topping(string toppingType, int weight)
        {
            this.ToppingType = toppingType;
            this.Weight = weight;
        }

        public string ToppingType
        {
            get 
            { 
                return toppingType; 
            }
            set 
            {
                if (!modifiers.ContainsKey(value.ToLower()))
                {
                    throw new ArgumentException($"Cannot place {value} on top of your pizza.");
                }
                toppingType = value; 
            }
        }
        
        public int Weight
        {
            get 
            { 
                return weight; 
            }
            set 
            {
                if (value<0||value>50)
                {
                    throw new ArgumentException($"{this.ToppingType} weight should be in the range [1..50].");
                }
                weight = value;
            }
        }

        public double Calories => toppingDefaultCalories*this.Weight*modifiers[this.toppingType.ToLower()];
    }
}
