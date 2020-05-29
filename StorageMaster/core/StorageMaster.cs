using System;
using System.Collections.Generic;
using System.Text;
using StorageMaster.Models.Products;
using StorageMaster.Models.Storage;
using StorageMaster.Models.Vehicles;

namespace StorageMaster.core
{
    class StorageMaster
    {
        public string AddProduct(string type, double price)
        {
            Product product = null;
            switch (type)
            {
                
                case "Gpu":
                    product= new Gpu(price);
                    break;
                case "HardDrive":
                product = new HardDrive(price);
                    break;
                case "SolidState":
                    product = new SolidStateDrive(price);
                    break;
                case "Ram":
                   product = new Ram(price);
                    break;
                default:
                    throw new InvalidOperationException("invalid product type");
            }
            ///product should be add to pool
            return ($"{type} added to pool");
        }
        public string RegisterStorage(string type,string name)
        {
            Storage storage = null;
            switch (type)
            {

                case "AutomatedWarehouse":
                    storage = new AutomatedWarehouse(name);
                    break;
                case "DistributionCenter":
                    storage = new DistributionCenter(name);
                    break;
                case "Warehouse":
                    storage = new Warehouse(name);
                    break;
            
                  
                default:
                    throw new InvalidOperationException("invalid storage type");
            }
            return ($"registerd {name}");

        }
        public string SelectedVehicle(Storage storageName,int garageSlot) {
           
            Vehicle result =storageName.GetVehicle(garageSlot);
            return ($"selected {result.GetType()}");
        
        
        }
        public string LoadVehicle(List<string> productName)
        {

        }
    }
}
