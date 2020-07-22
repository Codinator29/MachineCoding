using System;
using System.Collections.Generic;

namespace VehicleRentalService
{
    public interface IBookingStrategy
    {
        public int Priority { get; }

        IEnumerable<Inventory> GetInventory(string branchId, int seater);
    }
}
