using System;
using System.Collections.Generic;
using System.Text;

namespace StorageMaster.Models.Vehicles
{
    public class Truck : Vehicle
    {
        public Truck() : base (5)
        {
        }
        public override string ToString()
        {
            return "Truck";
        }
    }
}
