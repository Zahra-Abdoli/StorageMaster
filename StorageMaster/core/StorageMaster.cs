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
            Product product = Factories.ProductFactory.CreateProduct(type, price);
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
            Storage storage = Factories.StorageFactory.CreateStorage(type,name);
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
            var result= storageRegistry.Where(p => p.Name == storageName).First().GetVehicle(garageSlot);
           
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
            return $"selected{destination.Garage[destination.Garage.Count-1].ToString()}";

        }
        /// <summary>
        /// Upload vehicle from spesefic storage
        /// </summary>
        /// <param name="storageName"></param>
        /// <param name="garageSlot"></param>
        /// <returns></returns>
        public static string UnloadVehicle(string storageName, int garageSlot)
        {
            var result= storageRegistry.Where(p => p.Name == storageName).First().UnloadVehicle(garageSlot);
          
            return $"Unloaded {result} product at {storageName} ";
        }
        /// <summary>
        /// information of storage /// </summary>
        /// <param name="storageName"></param>
        public static string GetStorageStatuse(string storageName)
        {
            
            var storage = storageRegistry.Where(p => p.Name == storageName).First();
            var GroupbyList=storage.Products.GroupBy(p => p.ToString()).OrderByDescending(p => p.Count()).OrderBy(p => p.ToString()).ToList();
            string garageSlot = "";

            for (int i = 0; i < 10; i++)
            {
                if (i < storage.Garage.Count) garageSlot += storage.Garage[i].ToString();
                else garageSlot += "empty";
               if(i<9) garageSlot += "|";
          
            }
            string stock = "";
            for (int i = 0; i < GroupbyList.Count(); i++)
            {
                stock += $"{GroupbyList[i]}({GroupbyList[i].Count()})";
                ///gropby count
            }

            string result = $"stock({storage.WeightSum}/{storage.Capacity}):[{stock}]{Environment.NewLine} [{garageSlot}]";
            return  result ;
        }
        /// <summary>
        /// get all the storage in the storageRegistary and give summary
        /// </summary>
        /// <returns></returns>
        public static string GetSummary()
        {
            string result = "";
            storageRegistry.OrderByDescending(s => s.PriceSum);
            foreach (Storage storage in storageRegistry)
            {
                result += $"{storage.Name}:{Environment.NewLine}  storageWorth:{storage.PriceSum}00 {Environment.NewLine}";
            }
            return result;
            ///??? why ca not return in foreac

        }
    }
}
