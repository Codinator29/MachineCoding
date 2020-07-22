using System;
using System.Collections.Generic;
using System.Linq;

namespace VehicleRentalService
{
    public class City
    {
        public string CityName { get; set; }

        public City()
        {

        }

        public City(string cityName)
        {
            CityName = cityName;
        }

        public static List<Branch> Branches { get; set; } = new List<Branch>();

        public static Branch GetBranch(string branchId) => Branches.FirstOrDefault(x => x.BranchId.Equals(branchId));

        public static void AddBranch(string branch)
        {
            if (!Branches.Any(x => x.BranchId.Equals(branch)))
            {
                Branches.Add(new Branch { BranchId = branch, Bookings = new List<Booking>(), Inventory = new List<Inventory>()});
            }
        }
    }
}
