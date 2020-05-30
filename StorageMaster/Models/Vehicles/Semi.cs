using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace StorageMaster.Models.Vehicles
{
    public class Semi : Vehicle
    {
        public Semi() : base (10)
        {
          
        }
        public override string ToString()
        {
            return "Semi";
        }
    }
}
