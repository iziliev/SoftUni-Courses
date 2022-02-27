﻿using System;
using System.Collections.Generic;
using System.Text;

namespace _04_Pizza_Calories
{
    public class Dough
    {
        private const string exeptionType = "Invalid type of dough.";
        private const string exeptionWeght = "Dough weight should be in the range [1..200].";
        private const int doughtDefaultCalories = 2;

        private Dictionary<string, double> modifiers = new Dictionary<string, double>()
        {
            {"white",1.5 },
            {"wholegrain",1.0 },
            {"crispy",0.9 },
            {"chewy",1.1 },
            {"homemade",1.0 }
        };

        private string flourType;
        private string backingTechnique;
        private int weight;
        public Dough(string flourType, string backingTechnique, int weight)
        {
            this.FlourType = flourType;
            this.BackingTechnique = backingTechnique;
            this.Weight = weight;
        }

        public string FlourType
        {
            get
            {
                return flourType;
            }
            private set
            {
                if (!modifiers.ContainsKey(value.ToLower()))
                {
                    throw new Exception(exeptionType);
                }
                flourType = value;
            }
        }

        public string BackingTechnique
        {
            get
            {
                return backingTechnique;
            }
            private set
            {
                if (!modifiers.ContainsKey(value.ToLower()))
                {
                    throw new Exception(exeptionType);
                }
                backingTechnique = value;
            }
        }
        public int Weight
        {
            get
            {
                return weight;
            }
            private set
            {
                if (value < 1 || value > 200)
                {
                    throw new Exception(exeptionWeght);
                }
                weight = value;
            }
        }

        public double Calories => doughtDefaultCalories * this.weight * modifiers[this.FlourType.ToLower()] * modifiers[this.BackingTechnique.ToLower()];

    }
}
