namespace _02_Vehicles_Extension.Contracts
{
    public interface IVehicle
    {
        public double Fuel { get; }

        public double FuelConsumption { get; }

        public double TankCapacity { get; }

        public string Drive(double distance);

        public void Refuel(double liters);

        public bool CanDrive(double distance);

        public bool CanRefuel(double liters);

        public bool IsEmpty { get; set; }
    }
}
