using StorageMaster.Models.Vehicles;
using System;
using System.Collections.Generic;
using System.Text;

namespace StorageMaster.Models.Storage
{
    public class DistributionCenter : Storage
    {
        public DistributionCenter(string name): base(name, 2, 5)
        {
            Vehicle v1 = Factories.VehicleFactory.CreateVehicle("Van");
            Vehicle v2 = Factories.VehicleFactory.CreateVehicle("Van");
            Vehicle v3 = Factories.VehicleFactory.CreateVehicle("Van");
            Garage.Add(v1);
            Garage.Add(v2);
            Garage.Add(v3);

            
        }
    }
}
