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
            Van v1 = new Van();
            Van v2 = new Van();
            Van v3 = new Van();
            Garage.Add(v1);
            Garage.Add(v2);
            Garage.Add(v3);

            
        }
    }
}
