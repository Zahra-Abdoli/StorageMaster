using StorageMaster.Models.Vehicles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StorageMaster.Models.Storage
{
   public class AutomatedWarehouse : Storage
    {
        public AutomatedWarehouse(string name): base(name, 1, 2)
        {
            Vehicle truck = Factories.VehicleFactory.CreateVehicle("Truck");
            Garage.Add(truck);
        }
    }
}
