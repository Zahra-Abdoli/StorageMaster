using StorageMaster.core;
using StorageMaster.Models.Products;
using StorageMaster.Models.Storage;
using StorageMaster.Models.Vehicles;
using System;
using System.Collections;
using System.Collections.Generic;
using StorageMaster;

namespace StorageMaster
{
    class StartUp
    {
        static void Main(string[] args)
        {
            core.StorageMaster.AddProduct("Gpu", 45.3);
            core.StorageMaster.AddProduct("Gpu", 47.8);
            core.StorageMaster.AddProduct("HardDrive", 11.3);
            StorageMaster.core.StorageMaster.AddProduct("Ram", 9.3);
            StorageMaster.core.StorageMaster.AddProduct("Ram", 4.3);
            StorageMaster.core.StorageMaster.AddProduct("Gpu", 45.3);
            StorageMaster.core.StorageMaster.RegisterStorage("AutomatedWarehouse", "Apple");
            StorageMaster.core.StorageMaster.RegisterStorage("DistributionCenter", "Dell");
            StorageMaster.core.StorageMaster.RegisterStorage("AutomatedWarehouse", "Sumsong");
            StorageMaster.core.StorageMaster.RegisterStorage("AutomatedWarehouse", "Hawai");
            StorageMaster.core.StorageMaster.SelectedVehicle("Apple",0);
            StorageMaster.core.StorageMaster.SendVehicleTo("Apple", 0, "Dell");
            StorageMaster.core.StorageMaster.UploadVehicle("Sumsong", 1);
            StorageMaster.core.StorageMaster.GetStorageStatuse("Apple");
            StorageMaster.core.StorageMaster.GetSummary();


            Console.ReadKey();

        }

    }
}
