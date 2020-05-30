using System;
using System.Collections.Generic;
using System.Text;

namespace StorageMaster.Models.Products
{
    public class HardDrive : Product
    {
        public override string ToString()
        {
            return "HardDrive";
        }
        public HardDrive(double price) : base(price, 1)
        {
        }
    }
}
