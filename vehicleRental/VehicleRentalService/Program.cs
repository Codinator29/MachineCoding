using System;

namespace VehicleRentalService
{
    class Program
    {
        static void Main(string[] args)
        {
            //Driver Code
            Console.WriteLine("Rental System!");
            const string koranmangala = "koramangala";
            const string jayanagar = "jayanagar";
            const string malleshwaram = "malleshwaram";

            City.AddBranch(koranmangala);
            City.AddBranch(jayanagar);
            City.AddBranch(malleshwaram);

            var koranmangalaBranch = City.GetBranch(koranmangala);
            var jayanagarBranch = City.GetBranch(jayanagar);
            var malleshwaramBranch = City.GetBranch(malleshwaram);

            koranmangalaBranch.AddNewVehicle(Vehicle.VehicleType.SUV, 1, 12);
            koranmangalaBranch.AddNewVehicle(Vehicle.VehicleType.Sedan, 3, 10);
            koranmangalaBranch.AddNewVehicle(Vehicle.VehicleType.Bike, 3, 20);

            malleshwaramBranch.AddNewVehicle(Vehicle.VehicleType.SUV, 1, 11);
            malleshwaramBranch.AddNewVehicle(Vehicle.VehicleType.Sedan, 1, 10);
            malleshwaramBranch.AddNewVehicle(Vehicle.VehicleType.Hatchback, 2, 10);

            jayanagarBranch.AddNewVehicle(Vehicle.VehicleType.Sedan, 3, 11);
            jayanagarBranch.AddNewVehicle(Vehicle.VehicleType.Bike, 3, 30);
            jayanagarBranch.AddNewVehicle(Vehicle.VehicleType.Hatchback, 4, 8);

            malleshwaramBranch.AddNewBooking(new DateTime(2021, 02, 20, 10, 00, 00), new DateTime(2021, 02, 20, 12, 00, 00), Vehicle.VehicleType.Sedan);
            malleshwaramBranch.AddNewBooking(new DateTime(2021, 02, 20, 10, 00, 00), new DateTime(2021, 02, 20, 12, 00, 00), Vehicle.VehicleType.Sedan);

            koranmangalaBranch.AddNewBooking(new DateTime(2021, 02, 20, 10, 00, 00), new DateTime(2021, 02, 20, 12, 00, 00), Vehicle.VehicleType.SUV);
            koranmangalaBranch.AddNewBooking(new DateTime(2021, 02, 20, 10, 00, 00), new DateTime(2021, 02, 20, 12, 00, 00), Vehicle.VehicleType.SUV);

            //Display System Stats
            foreach(var branch in City.Branches)
            {
                Console.WriteLine(branch.BranchId);
                branch.DisplaySystemView();
                Console.WriteLine();
            }
        }

        /*static void Display(string booking)
        {
            if (booking.Equals(Constants.NoBooking))
            {
                Console.WriteLine("No Booking");
            }
            else
            {
                Console.WriteLine($"Booking Id: {booking} ");
            }
        }*/
    }
}
