using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CocktailParty
{
    public class Cocktail
    {
        private List<Ingredient> ingredients;

        public Cocktail(string name, int capacity, int maxAlcoholLevel)
        {
            this.Name = name;
            this.Capacity = capacity;
            this.MaxAlcoholLevel = maxAlcoholLevel;
            this.ingredients = new List<Ingredient>();
        }

        public int CurrentAlcoholLevel 
        {
            get 
            {
                return this.ingredients.Sum(x => x.Alcohol);
            }
        }
        public string Name { get; set; }
        public int Capacity { get; set; }
        public int MaxAlcoholLevel { get; set; }

        public void Add(Ingredient ingredient)
        {
            if (!this.ingredients.Any(x => x.Name == ingredient.Name) && this.Capacity>this.ingredients.Count)
            {
                this.ingredients.Add(ingredient);
            }
        }

        public bool Remove(string name)
        {
            if (this.ingredients.Any())
            {
                var ingredient = FindIngredient(name);

                if (ingredient != null)
                {
                    this.ingredients.Remove(ingredient);
                    return true;
                }
            }
            
            return false;
        }

        public Ingredient FindIngredient(string name)
        {
            var ingredient = this.ingredients.FirstOrDefault(x => x.Name == name);
            
            return ingredient != null ? ingredient : null;
        }

        public Ingredient GetMostAlcoholicIngredient()
        {
            if (this.ingredients.Any())
            {
                return this.ingredients.OrderByDescending(x=>x.Alcohol).FirstOrDefault();
            }
            return null;
        }

        public string Report()
        {
            var sb = new StringBuilder();
            sb.AppendLine($"Cocktail: {this.Name} - Current Alcohol Level: {this.CurrentAlcoholLevel}");
            foreach (var item in this.ingredients)
            {
                sb.AppendLine($"{item}");
            }

            return sb.ToString().Trim();
        }
    }
}
