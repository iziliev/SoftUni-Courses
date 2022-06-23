﻿using Easter.Models.Bunnies.Contracts;
using Easter.Models.Dyes.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Easter.Models.Bunnies
{
    public abstract class Bunny : IBunny
    {
        private string name;
        private int energy;
        private List<IDye> dyes;
        public Bunny(string name, int energy)
        {
            this.Name = name;
            this.Energy = energy;
            this.dyes = new List<IDye>();
        }
        public string Name
        {
            get => name;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException("Bunny name cannot be null or empty.");
                }
                name = value;
            }
        }

        public int Energy
        {
            get => energy;
            protected set => energy = value;
        }

        public ICollection<IDye> Dyes => this.dyes;

        public void AddDye(IDye dye)
        {
            this.dyes.Add(dye);
        }

        public abstract void Work();

        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.AppendLine($"Name: {this.Name}");
            sb.AppendLine($"Energy: {this.Energy}");
            sb.AppendLine($"Dyes: {this.Dyes.Where(x=>x.Power>0).Count()} not finished");
            return sb.ToString().Trim();
        }
    }
}
