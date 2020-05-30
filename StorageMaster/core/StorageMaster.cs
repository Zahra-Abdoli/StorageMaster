using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using StorageMaster.Models.Products;
using StorageMaster.Models.Storage;
using StorageMaster.Models.Vehicles;

namespace StorageMaster.core
{
    class StorageMaster
    {
        private List<Product> pool;

        public List<Product> Pool
        {
            get { return pool; }
            set { pool = value; }
        }

        private List<Storage> storageRegistry;

        public List<Storage> StorageRegistary
        {
            get { return storageRegistry; }
            set { storageRegistry = value; }
        }

        public string AddProduct(string type, double price)
        {
            Product product = null;
            switch (type)
            {

                case "Gpu":
                    product = new Gpu(price);
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
            pool.Add(product);
            return ($"{type} added to pool");
        }
        public string RegisterStorage(string type, string name)
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
            storageRegistry.Add(storage);
            return ($"registerd {name}");

        }
        public string SelectedVehicle(string storageName, int garageSlot)
        {
            var storage = storageRegistry.Where(p => p.Name == storageName).First();
            Vehicle result = storage.GetVehicle(garageSlot);
            return ($"selected {result.ToString()}");


        }
        public string LoadVehicle(List<string> productName, Vehicle vehicle)
        {
            int productCount = 0;
            foreach (var item in productName)
            {


                var product = pool.Where(p => p.ToString() == item).Last();
                if (product == null) throw new InvalidOperationException($"{item} is out of stock");
                vehicle.LoadProduct(product);
                pool.Reverse();
                pool.Remove(product);
                pool.Reverse();
                productCount++;

            }
            return ($"loded {productCount} product into{vehicle.ToString()}");
        }
        public string SendVehicleTo(string sourceName, int sourceGarageSlot, string destinationName)
        {
            var source = storageRegistry.Where(p => p.Name == sourceName).First();
            var destination = storageRegistry.Where(p => p.Name == destinationName).First();
            source.SendVehicleTo(sourceGarageSlot, destination);
            return ($"selected{destination.Garage[destination.Garage.Count].ToString()}");

        }
        public string UploadVehicle(string storageName,int garageSlot)
        {
            var storage = storageRegistry.Where(p => p.Name == storageName).First();
            int result=storage.UnloadVehicle(garageSlot);
            return $"Unloaded {result} product at {storageName} ";
        }
    }
}
