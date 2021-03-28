namespace Vehicles
{
    public interface IVehicle
    {
        public double FuelQuantity { get; set; }

        public double FuelConsumption { get; set; }

        void Drive(double distance);

        void Refuel(double liters);
    }
}