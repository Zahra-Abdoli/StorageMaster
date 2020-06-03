using StorageMaster.Models.Vehicles;
using System;
using System.Collections.Generic;
using System.Text;

namespace StorageMaster.Models.Storage
{
    public  class Warehouse : Storage
    {
        public Warehouse(string name) :base( name,10,10)
        {
            Vehicle s1 = Factories.VehicleFactory.CreateVehicle("Semi");
            Vehicle s2 = Factories.VehicleFactory.CreateVehicle("Semi");
            Vehicle s3 = Factories.VehicleFactory.CreateVehicle("Semi");
            Garage.Add(s1);
            Garage.Add(s2);
            Garage.Add(s3);
           
        }
    }
}
