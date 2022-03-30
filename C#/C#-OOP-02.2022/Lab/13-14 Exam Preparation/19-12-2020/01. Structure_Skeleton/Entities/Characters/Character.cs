using System;

using WarCroft.Constants;
using WarCroft.Entities.Inventory;
using WarCroft.Entities.Items;

namespace WarCroft.Entities.Characters.Contracts
{
    public abstract class Character
    {
        private string name;
        private double health;
        private double armor;

        public Character(string name, double health, double armor, double abilityPoints, Bag bag)
        {
            this.Name = name;
            this.BaseHealth= health;
            this.Health = health;
            this.BaseArmor= armor;
            this.Armor = armor;
            this.AbilityPoints = abilityPoints;
            this.Bag = bag;
        }

        public string Name
        {
            get => name;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Name cannot be null or whitespace!");
                }
                name = value;
            }
        }

        public double BaseHealth { get; private set; }

        public double Health
        {
            get => health;
            internal set
            {
                if (value > this.BaseHealth)
                {
                    value = BaseHealth;
                }
                if (value < 0)
                {
                    value = 0;
                }
                health = value;
            }
        }

        public double BaseArmor { get; private set; }

        public double Armor 
        { 
            get => armor;
            private set 
            {
                if (value < 0)
                {
                    value = 0;
                }
                armor = value; 
            }
        }

        public double AbilityPoints { get; private set; }

        public Bag Bag { get; private set; }

        public bool IsAlive { get; set; } = true;

        public void TakeDamage(double hitPoints)
        {
            EnsureAlive();

            if (this.Armor < hitPoints)
            {
                var points = hitPoints - this.Armor;

                this.Armor -= hitPoints;

                this.Health-=points;

                if (this.Health<=0)
                {
                    this.IsAlive = false;
                }
            }
            else
            {
                this.Armor-=hitPoints;
            }
        }

        public void UseItem(Item item)
        {
            EnsureAlive();
            item.AffectCharacter(this);
        }

        protected void EnsureAlive()
        {
            if (!this.IsAlive)
            {
                throw new InvalidOperationException(ExceptionMessages.AffectedCharacterDead);
            }
        }

        public override string ToString()
        {
            var aliveDead = this.IsAlive ? "Alive" : "Dead";
            return $"{this.Name} - HP: {this.Health}/{this.BaseHealth}, AP: {this.Armor}/{this.BaseArmor}, Status: {aliveDead}";
        }
    }
}