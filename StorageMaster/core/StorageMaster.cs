using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using StorageMaster.Models.Products;
using StorageMaster.Models.Storage;
using StorageMaster.Models.Vehicles;

namespace StorageMaster.core
{

    public class StorageMaster
    {
        private StorageMaster()
        {


        }
        private static List<Product> pool = new List<Product>();
        public static List<Product> Pool
        {
            get { return pool; }
            set { pool = value; }
        }

        private static List<Storage> storageRegistry = new List<Storage>();

        public static List<Storage> StorageRegistary
        {
            get { return storageRegistry; }
            set { storageRegistry = value; }
        }

        /// <summary>
        /// add new product with one of the tree type
        /// </summary>
        /// <param name="type"></param>
        /// <param name="price"></param>
        /// <returns></returns>
        public static string AddProduct(string type, double price)
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
        /// <summary>
        /// register new storage
        /// </summary>
        /// <param name="type"></param>
        /// <param name="name"></param>
        /// <returns></returns>
        public static string RegisterStorage(string type, string name)
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
        /// <summary>
        /// select one vehicle from spesefic storage and slot
        /// </summary>
        /// <param name="storageName"></param>
        /// <param name="garageSlot"></param>
        /// <returns></returns>
        public static string SelectedVehicle(string storageName, int garageSlot)
        {
            var storage = storageRegistry.Where(p => p.Name == storageName).First();
            Vehicle result = storage.GetVehicle(garageSlot);
            return $"selected {result.ToString()}";


        }
        /// <summary>
        /// load list of product from pool to vehicle 
        /// </summary>
        /// <param name="productName"></param>
        /// <param name="vehicle"></param>
        /// <returns></returns>
        public static string LoadVehicle(List<string> productName, Vehicle vehicle)
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
            return $"loded {productCount} product into{vehicle.ToString()}";
        }
        /// <summary>
        /// send vehicle from source storage to destination storage
        /// </summary>
        /// <param name="sourceName"></param>
        /// <param name="sourceGarageSlot"></param>
        /// <param name="destinationName"></param>
        /// <returns></returns>
        public static string SendVehicleTo(string sourceName, int sourceGarageSlot, string destinationName)
        {
            var source = storageRegistry.Where(p => p.Name == sourceName).First();
            var destination = storageRegistry.Where(p => p.Name == destinationName).First();
            source.SendVehicleTo(sourceGarageSlot, destination);
            return $"selected{destination.Garage[destination.Garage.Count].ToString()}";

        }
        /// <summary>
        /// Upload vehicle from spesefic storage
        /// </summary>
        /// <param name="storageName"></param>
        /// <param name="garageSlot"></param>
        /// <returns></returns>
        public static string UploadVehicle(string storageName, int garageSlot)
        {
            var storage = storageRegistry.Where(p => p.Name == storageName).First();
            int result = storage.UnloadVehicle(garageSlot);
            return $"Unloaded {result} product at {storageName} ";
        }
        /// <summary>
        /// information of storage /// </summary>
        /// <param name="storageName"></param>
        public static string GetStorageStatuse(string storageName)
        {
            
            var storage = storageRegistry.Where(p => p.Name == storageName).First();
            storage.Products.GroupBy(p => p.ToString()).OrderByDescending(p => p.Count()).OrderBy(p => p.ToString());
            string garageSlot = null;

            for (int i = 0; i < 10; i++)
            {
                if (i <= storage.Garage.Count) garageSlot += storage.Garage[i].ToString();
                else garageSlot += "empty";
                garageSlot += "|";

            }
            string stock = null;
            for (int i = 0; i < storage.Products.Count; i++)
            {
                stock += $"{storage.Products[i]}()";
                ///gropby count
            }


            return $"stock({storage.WeightSum}/{storage.Capacity}):[{stock}] \n [{garageSlot}]" ;
        }
        /// <summary>
        /// get all the storage in the storageRegistary and give summary
        /// </summary>
        /// <returns></returns>
        public static string GetSummary()
        {
            string result = null;
            storageRegistry.OrderByDescending(s => s.PriceSum);
            foreach (Storage storage in storageRegistry)
            {
                result = $"{storage.Name}: \n  storageWorth:{storage.PriceSum}00 ";
            }
            return result;
            ///??? why ca not return in foreac

        }
    }
}
