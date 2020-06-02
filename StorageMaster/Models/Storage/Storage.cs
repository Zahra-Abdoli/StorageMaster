using StorageMaster.Models.Products;
using StorageMaster.Models.Vehicles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;

namespace StorageMaster.Models.Storage
{
    public abstract class Storage
    {
        private string name;
        private int capacity;
        private int garageSlots;
        private bool isFull;
        private List<Product> products;
        private List<Vehicle> garage;
        private double priceSum;


        public double PriceSum
        {
            get
            {
                foreach (Product product in products)
                {
                    priceSum += product.Price;
                }
                return priceSum;
            }
        }
        private double weightSum;

        public double WeightSum
        {
            get
            {
                foreach (Product product in products)
                {
                    weightSum += product.Weight;
                }
                return weightSum;
            }

        }




        public Storage(string name, int capacity, int garageSlots)
        {
            Name = name;
            Capacity = capacity;
            GarageSlots = garageSlots;
            Garage = new List<Vehicle>(garageSlots);
            Products = new List<Product>(capacity);

        }

        public string Name { get => name; set => name = value; }
        public int Capacity { get => capacity; set => capacity = value; }
        public int GarageSlots { get => garageSlots; set => garageSlots = value; }
        public bool IsFull
        {
            /// we do not need set because it is a readonly property 
            get

            {


                if (weightSum >= capacity)
                    this.isFull = true;
                return isFull;

            }

        }
        public List<Product> Products { get => products; private set => products = value; }
        public List<Vehicle> Garage { get => garage; protected set => garage = value; }

        /// <summary>
        /// choose one vehicle if it is anyone
        /// </summary>
        /// <param name="garageSlot"></param>
        /// <returns></returns>
        public Vehicle GetVehicle(int garageSlot)
        {
            if (garageSlot >= GarageSlots)

                throw new InvalidOperationException("Invalid Garage Slot");

            else if (Garage[garageSlot - 1] == null)
                throw new InvalidOperationException("No Vehicle is the Garage Slot");
            else
                return Garage[garageSlot - 1];

        }


        /// <summary>
        /// send vehicle from garage slot to another storage
        /// </summary>
        /// <param name="garageSlot"></param>
        /// <param name="deliveryLocation"></param>
        /// <returns></returns>
        public int SendVehicleTo(int garageSlot, Storage deliveryLocation)
        {
            Vehicle v = GetVehicle(garageSlot);
            if (deliveryLocation.garage.Count < deliveryLocation.GarageSlots)
                deliveryLocation.garage.Add(v);


            else
                throw new InvalidOperationException("No room in garage.");
            return deliveryLocation.garage.Count;
        }

        /// <summary>
        /// make the corrent vehicle unLoade
        /// </summary>
        /// <param name="garageSlot"></param>
        /// <returns></returns>
        public int UnloadVehicle(int garageSlot)
        {
            if (IsFull)
                throw new InvalidOperationException("Storage is full");
            var v = GetVehicle(garageSlot);
            int unloaded = 0;

            while(!v.IsEmpty)
            {

                if (!this.IsFull)

                products.Add(v.Trunk[v.Trunk.Count-1]);
                v.UnLoad(v.Trunk[v.Trunk.Count - 1]);

                unloaded++;
            }

            return unloaded;
        }
    }






}


