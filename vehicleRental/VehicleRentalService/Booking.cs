using System;
using System.Collections.Generic;
using System.Linq;

namespace VehicleRentalService
{
    public class Booking
    {
        public string BookingId { get; set; }

        public Timeslot Timeslot { get; set; }

        public Vehicle.VehicleType VehicleType { get; set; }

        public List<IBookingStrategy> bookingStrategies { get; set; }

        public Booking()
        {
        }

        /*public Booking(DateTime startTime, DateTime endTime, Vehicle.VehicleType vehicleType)
        {
            Timeslot = new Timeslot(startTime, endTime);
            VehicleType = vehicleType;
            BookingId = new Guid().ToString();
        }*/

        public bool Book(DateTime startTime, DateTime endTime, Vehicle.VehicleType vehicleType, string branchId)
        {
            System.Reflection.Assembly ass = System.Reflection.Assembly.GetEntryAssembly();
            bookingStrategies = new List<IBookingStrategy>();
            foreach (System.Reflection.TypeInfo ti in ass.DefinedTypes)
            {
                if (ti.ImplementedInterfaces.Contains(typeof(IBookingStrategy)))
                {
                     bookingStrategies.Add(ass.CreateInstance(ti.FullName) as IBookingStrategy);
                }
            }

            foreach(var bookingStrategy in bookingStrategies.OrderBy(x => x.Priority))
            {
                var availableInventories = bookingStrategy.GetInventory(branchId, Vehicle.GetSeatingCapacity(vehicleType));
                var availableInventory = availableInventories.FirstOrDefault(x => x.Count > 0);
                if(availableInventory?.Count == 0)
                {
                    continue;
                }

                if(availableInventory?.Count > 0)
                {
                    Timeslot = new Timeslot(startTime, endTime);
                    VehicleType = vehicleType;
                    BookingId = Guid.NewGuid().ToString();
                    return true;
                }
            }

            return false;

        }
    }

    public class Timeslot
    {
        public DateTime StartTime { get; set; }

        public DateTime EndTime { get; set; }

        public Timeslot(DateTime startDate, DateTime endDate)
        {
            StartTime = startDate;
            EndTime = endDate;
        }
    }
}
