using StorageMaster.core;
using StorageMaster.Models.Products;
using StorageMaster.Models.Storage;
using StorageMaster.Models.Vehicles;
using System;
using System.Collections;
using System.Collections.Generic;
using StorageMaster;
using StorageMaster.IO;

namespace StorageMaster
{
    class StartUp
    {
        static void Main(string[] args)
        {
            var r = new Engine();
            r.RunEngine();


        }
    }
}
