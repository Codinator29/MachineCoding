using System;
using System.Collections.Generic;
using System.Linq;

namespace VehicleRentalService
{
    public class Branch
    {
        public string BranchId { get; set; }

        public List<Inventory> Inventory { get; set; }

        public List<Booking> Bookings { get; set; }

        public Branch()
        {
        }

        public Branch(string branchId)
        {
            BranchId = branchId;
        }

        public void AddNewVehicle(Vehicle.VehicleType vehicleType, int count, int price)
        {
            if (Inventory.Any(x => x.VehicleType.Equals(vehicleType)))
            {
                foreach(var x in Inventory)
                {
                    if (x.VehicleType.Equals(vehicleType))
                    {
                        x.Count += count;
                    }
                }
            }
            else
            {
                Vehicle vehicle = new Vehicle(vehicleType);
                Inventory.Add(new Inventory(vehicleType, vehicle, count, price));
            }
        }

        private void RemoveVehicle(Vehicle.VehicleType vehicleType, int count)
        {
            if (Inventory.Any(x => x.VehicleType.Equals(vehicleType)))
            {
                foreach (var x in Inventory)
                {
                    if (x.VehicleType.Equals(vehicleType))
                    {
                        if (x.Count >= count)
                        {
                            x.Count -= count;
                            break;
                        }
                    }
                }
            }
        }

        //public void RemoveVehicle(string vehicleId)
        //{
        //    foreach(var inventory in Inventory)
        //    {
        //        if (inventory.Vehicle.VehicleId.Equals(vehicleId))
        //        {
        //            if (inventory.Count > 0)
        //            {
        //                inventory.Count--;
        //                break;
        //            }
        //        }
        //    }
        //}

        public string AddNewBooking(DateTime startTime, DateTime endTime, Vehicle.VehicleType VehicleType)
        {
            var currentDateTime = DateTime.Now;
            if (DateTime.Compare(currentDateTime, startTime) > 0 || DateTime.Compare(startTime, endTime) > 0)
            {
                throw new ArgumentOutOfRangeException("Starttime and Endtime are not in future or Endtime falls before Starttime");
            }
            else
            {
                var booking = new Booking();
                var bookingDone = booking.Book(startTime, endTime, VehicleType, BranchId);

                if (bookingDone)
                {
                    Bookings.Add(booking);
                    RemoveVehicle(VehicleType, 1);
                    return booking.BookingId;
                }
                return Constants.NoBooking;
            }
        }

        public void DisplaySystemView()
        {
            foreach(var inventory in Inventory)
            {
                if(inventory.Count == 0)
                {
                    Console.WriteLine($"All {Enum.GetName(typeof(Vehicle.VehicleType), inventory.VehicleType)} are booked.");
                }
                else
                {
                    Console.WriteLine($"{Enum.GetName(typeof(Vehicle.VehicleType), inventory.VehicleType)} is available for Rs.{inventory.Price}");
                }
            }
        }

        /*public void RemoveBooking(string bookingId)
        {
            foreach(var booking in Bookings)
            {
                if (booking.BookingId.Equals(bookingId))
                {
                    Bookings.Remove(booking);
                    break;
                }
            }
        }*/
    }
}
