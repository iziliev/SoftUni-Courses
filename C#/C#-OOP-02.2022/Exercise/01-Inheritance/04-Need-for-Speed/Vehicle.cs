namespace NeedForSpeed
{
    public class Vehicle
    {
        private const double DefaultFuelConsumption = 1.25;
        public Vehicle(int horsePower, double fuel)
        {
            this.HorsePower = horsePower;
            this.Fuel = fuel;
            this.FuelConsumprion = DefaultFuelConsumption;
        }

        public int HorsePower { get; set; }
        public double Fuel { get; set; }
        public virtual double FuelConsumprion {get; private set; }
        public virtual void Drive(double kilometers)
        {
            this.Fuel -= this.FuelConsumprion*kilometers;
        }
    }
}
