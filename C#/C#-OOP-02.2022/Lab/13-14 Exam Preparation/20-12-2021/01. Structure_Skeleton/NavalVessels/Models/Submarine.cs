using NavalVessels.Models.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace NavalVessels.Models
{
    public class Submarine : Vessel, ISubmarine
    {
        private bool submergeMode;

        public Submarine(string name, double mainWeaponCaliber, double speed)
: base(name, mainWeaponCaliber, speed, 200)
        {
            this.SubmergeMode = false;
        }

        public bool SubmergeMode 
        { 
            get => submergeMode; 
            private set => submergeMode = value; 
        }

        public override void RepairVessel()
        {
            this.ArmorThickness = 200;
        }

        public void ToggleSubmergeMode()
        {
            if (!this.SubmergeMode)
            {
                this.SubmergeMode = true;
                this.MainWeaponCaliber += 40;
                this.Speed -= 4;
            }
            else
            {
                this.SubmergeMode= false;
                this.MainWeaponCaliber -= 40;
                this.Speed += 4;
            }
        }

        public override string ToString()
        {
            var sb = new StringBuilder(); sb.AppendLine(base.ToString());
            sb.AppendLine(!this.SubmergeMode ? " *Submerge mode: OFF" : " *Submerge mode: ON");
            return sb.ToString().Trim();
        }
    }
}
