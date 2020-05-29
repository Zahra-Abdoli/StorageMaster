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
            Semi s1 = new Semi();
            Semi s2 = new Semi();
            Semi s3 = new Semi();
            Garage.Add(s1);
            Garage.Add(s2);
            Garage.Add(s3);
           
        }
    }
}
