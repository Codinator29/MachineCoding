using System;
using System.Collections.Generic;

namespace VehicleRentalService
{
    public class Vehicle
    {
        public string VehicleId { get; set; }

        public enum VehicleType
        {
            SUV,
            Sedan,
            Hatchback,
            Bike
        }

        private static readonly Dictionary<VehicleType, int> SeatMap = new Dictionary<VehicleType, int> { { VehicleType.SUV, 7},
            { VehicleType.Sedan, 5 }, { VehicleType.Hatchback, 5 }, { VehicleType.Bike, 2 }};

        public VehicleType VehiclType { get; set; }

        public int Seater { get; set; }

        public Vehicle(VehicleType vehicleType)
        {
            VehicleId = new Guid().ToString();
            VehiclType = vehicleType;
            Seater = SeatMap[vehicleType];
        }

        public static int GetSeatingCapacity(Vehicle.VehicleType vehicleType) => SeatMap[vehicleType];
    }
}
