using System;
using System.Collections.Generic;
using System.Text;

namespace RawData
{
    public class Cargo
    {
        public Cargo(string cargoType,Tire[] tires,int weight)
        {
            this.CargoType = cargoType;
            this.Tires = tires;
            this.Weight = weight;
        }
        public string CargoType { get; set; }
        public Tire[] Tires { get; set; }
        public int Weight { get; set; }
    }
}
