using System;
using System.Collections.Generic;
using System.Linq;

namespace VehicleRentalService
{
    public class Inventory
    {
        public Vehicle.VehicleType VehicleType { get; set; }

        public Vehicle Vehicle { get; set; }

        public int Price { get; set; }

        public int Count { get; set; }

        public Inventory()
        {
        }

        public Inventory(Vehicle.VehicleType vehicleType, Vehicle vehicle, int count, int price)
        {
            VehicleType = vehicleType;
            Count = count;
            Price = price;
            Vehicle = vehicle;
        }

        /*public void InitiateInventory()
        {
            var values = Enum.GetValues(typeof(Vehicle.VehicleType)).Cast<Vehicle.VehicleType>();
            foreach (var vehicleType in values)
            {

            }
        }*/
    }
}
