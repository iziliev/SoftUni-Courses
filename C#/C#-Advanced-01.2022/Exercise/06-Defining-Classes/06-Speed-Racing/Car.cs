using System;
using System.Collections.Generic;
using System.Text;

namespace SpeedRacing
{
    public class Car
    {
        private string model;
        private double fuelAmount;
        private double fuelConsumptionPerKilometer;
        private double travelledDistance;
        public Car(string model, double fuelAmount, double fuelConsumptionPerKilometer)
        {
            this.Model = model;
            this.FuelAmount = fuelAmount;
            this.FuelConsumptionPerKilometer = fuelConsumptionPerKilometer; ;
            this.travelledDistance = 0;
        }
        public string Model { get; set; }
        public double FuelAmount { get; set; }
        public double FuelConsumptionPerKilometer { get; set; }
        public double TravelledDistance { get; set; }

        public void DriveCar(string model,int amountOfKm)
        {
            if (this.FuelAmount - (amountOfKm*this.FuelConsumptionPerKilometer)>=0)
            {
                this.FuelAmount -= amountOfKm * this.FuelConsumptionPerKilometer;
                this.TravelledDistance += amountOfKm;
            }
            else
            {
                Console.WriteLine("Insufficient fuel for the drive");
            }
        }
        public override string ToString()
        {
            return $"{this.Model} {this.FuelAmount:f2} {this.TravelledDistance}";
        }

    }
}
