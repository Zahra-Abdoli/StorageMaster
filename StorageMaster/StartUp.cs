using StorageMaster.Models.Products;
using StorageMaster.Models.Storage;
using StorageMaster.Models.Vehicles;
using System;
using System.Collections;
using System.Collections.Generic;

namespace StorageMaster
{
    class StartUp
    {
        static void Main(string[] args)
        {
            AutomatedWarehouse myAutomatedWarehouse = new AutomatedWarehouse("My AutomatedWareHouse");
            Warehouse myWarehouse = new Warehouse("My WareHouse");
            var vehicle = myWarehouse.Garage[2];
            Console.WriteLine(vehicle.Capacity);
            var result = myWarehouse.SendVehicleTo(1, myAutomatedWarehouse);
            Console.WriteLine(result);
            myWarehouse.UnloadVehicle(1);
            Console.WriteLine(myWarehouse.Capacity);
            Console.WriteLine(myWarehouse.Products.Count);
            Console.ReadKey();
        }

    }
}
