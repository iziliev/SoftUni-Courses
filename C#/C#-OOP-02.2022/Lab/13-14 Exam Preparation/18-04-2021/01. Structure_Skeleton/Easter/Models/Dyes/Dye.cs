using Easter.Models.Dyes.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace Easter.Models.Dyes
{
    public class Dye : IDye
    {
        private int power;

        public Dye(int power)
        {
            this.Power = power;
        }
        public int Power 
        { 
            get => power; 
            private set => power = value; 
        }

        public bool IsFinished()
        {
            return this.Power == 0;
        }

        public void Use()
        {
            if (this.Power - 10 < 0)
            {
                this.Power = 0;
            }
            else
            {
                this.Power -= 10;
            }
        }
    }
}
