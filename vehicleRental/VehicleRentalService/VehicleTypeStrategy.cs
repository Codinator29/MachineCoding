using System;
using System.Collections.Generic;
using System.Linq;

namespace VehicleRentalService
{
    public class VehicleTypeStrategy: IBookingStrategy
    {
        public VehicleTypeStrategy()
        {
        }

        public int Priority => 2;

        public IEnumerable<Inventory> GetInventory(string branchId, int seater)
        {
            return City.GetBranch(branchId).Inventory.Where(x => x.Vehicle.Seater == seater).OrderBy(x => x.VehicleType);
        }
    }
}
