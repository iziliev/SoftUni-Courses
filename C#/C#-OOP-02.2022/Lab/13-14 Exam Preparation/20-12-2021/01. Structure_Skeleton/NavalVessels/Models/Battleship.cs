using NavalVessels.Models.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace NavalVessels.Models
{
    public class Battleship : Vessel,IBattleship
    {
        private bool sonarMode;

        public Battleship(string name, double mainWeaponCaliber, double speed)
: base(name, mainWeaponCaliber, speed, 300)
        {
            this.SonarMode = false;
        }

        public bool SonarMode
        {
            get => sonarMode;
            private set => sonarMode = value;
        }

        public override void RepairVessel()
        {
            this.ArmorThickness = 300;
        }

        public void ToggleSonarMode()
        {
            if (!this.SonarMode)
            {
                this.SonarMode = true;
                this.MainWeaponCaliber += 40;
                this.Speed -= 5;
            }
            else
            {
                this.SonarMode= false;
                this.MainWeaponCaliber -= 40;
                this.Speed += 5;
            }
        }

        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.AppendLine(base.ToString());
            sb.AppendLine(!this.SonarMode ? " *Sonar mode: OFF" : " *Sonar mode: ON");
            return sb.ToString().Trim();
        }
    }
}
