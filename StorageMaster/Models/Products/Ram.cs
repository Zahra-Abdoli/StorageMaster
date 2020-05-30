using System;
using System.Collections.Generic;
using System.Text;

namespace StorageMaster.Models.Products
{
    public class Ram : Product
    {
        public override string ToString()
        {
            return "Ram";
        }
        public Ram(double price) : base (price, 0.1)
        {
        }
    }
}
