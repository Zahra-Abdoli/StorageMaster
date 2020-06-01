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
            core.StorageMaster.AddProduct("Ram", 9.3);
            core.StorageMaster.AddProduct("Ram", 9.3);
            core.StorageMaster.AddProduct("Ram", 4.3);
            core.StorageMaster.AddProduct("Gpu", 45.3);
            core.StorageMaster.RegisterStorage("AutomatedWarehouse", "Apple");
            core.StorageMaster.RegisterStorage("DistributionCenter", "Dell");
            core.StorageMaster.RegisterStorage("AutomatedWarehouse", "Sumsong");
            core.StorageMaster.RegisterStorage("AutomatedWarehouse", "Hawai");
            core.StorageMaster.SelectedVehicle("Apple", 1);
            core.StorageMaster.SendVehicleTo("Apple", 1, "Dell");
            core.StorageMaster.UnloadVehicle("Sumsong", 1);
            core.StorageMaster.GetStorageStatuse("Apple");
           /// core.StorageMaster.LoadVehicle( new List<string>() { "Gpu", "HardDrive" },);
            core.StorageMaster.GetSummary();


            Console.ReadKey();

        }

    }
}
