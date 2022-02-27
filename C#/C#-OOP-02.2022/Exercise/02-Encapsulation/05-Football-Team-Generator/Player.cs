using System;
using System.Collections.Generic;
using System.Text;

namespace _05_Football_Team_Generator
{
    public class Player
    {
        private const string errorStats = "should be between 0 and 100.";
        private const string errorName = "A name should not be empty.";
        private string name;
        private int endurance;
        private int sprint;
        private int dribble;
        private int passing;
        private int shooting;
        public Player(string name, int endurance, int sprint, int dribble, int passing, int shooting)
        {
            this.Name = name;
            this.Endurance = endurance;
            this.Sprint = sprint;
            this.Dribble = dribble;
            this.Passing = passing;
            this.Shooting = shooting;
        }

        public string Name
        {
            get
            {
                return name;
            }
            private set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException(errorName);
                }
                name = value;
            }
        }

        public int Endurance
        {
            get
            {
                return endurance;
            }
            private set
            {
                ValidateSkill(value, nameof(Endurance));
                endurance = value;
            }
        }


        public int Sprint
        {
            get
            {
                return sprint;
            }
            private set
            {
                ValidateSkill(value, nameof(Sprint));
                sprint = value;
            }
        }

        public int Dribble
        {
            get
            {
                return dribble;
            }
            private set
            {
                ValidateSkill(value, nameof(Dribble));
                dribble = value;
            }
        }

        public int Passing
        {
            get
            {
                return passing;
            }
            private set
            {
                ValidateSkill(value, nameof(Passing));
                passing = value;
            }
        }

        public int Shooting
        {
            get
            {
                return shooting;
            }
            set
            {
                ValidateSkill(value, nameof(Shooting));
                shooting = value;
            }
        }
        public double SkillLevel => (this.Endurance + this.Sprint + this.Dribble + this.Passing + this.Shooting) / 5.0;
        private static void ValidateSkill(int value, string varName)
        {
            if(value < 0 || value > 100)
            {
                throw new ArgumentException($"{varName} {errorStats}");
            }
        }

    }
}
