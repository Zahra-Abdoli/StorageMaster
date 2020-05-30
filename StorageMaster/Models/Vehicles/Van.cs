using System;
using System.Collections.Generic;
using System.Text;

namespace StorageMaster.Models.Vehicles
{
    public class Van : Vehicle
    {
        public Van() : base (2)
        {
        }
        public override string ToString()
        {
            return "Van";
        }
    }
}
