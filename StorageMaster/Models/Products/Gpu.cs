using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace StorageMaster.Models.Products
{
    public class Gpu : Product
    {
        public override string ToString()
        {
            return "Gpu";
        }
        public Gpu(double price) : base (price, 0.7)
        {
        }
    }
}
