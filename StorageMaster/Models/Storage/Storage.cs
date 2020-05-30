﻿using StorageMaster.Models.Products;
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

        public Storage(string name, int capacity, int garageSlots)
        {
            Name = name;
            Capacity = capacity;
            GarageSlots = garageSlots;
            this.Garage = new List<Vehicle>(garageSlots);
            this.Products = new List<Product>(capacity);
       
        }

        public string Name { get => name; set => name = value; }
        public int Capacity { get => capacity; set => capacity = value; }
        public int GarageSlots { get => garageSlots; set => garageSlots = value; }
        public bool IsFull
        {
            /// we do not need set because it is a readonly property 
            get
            
            {
                    double sumWeight = 0;
                    foreach (Product product in Products)
                    {
                        sumWeight += product.Weight;
                    }
                    if (sumWeight >= capacity)
                        this.isFull = true;
                     return isFull;
                
            }
          
        }
        public List<Product> Products { get => products; private set => products = value; }
        public List<Vehicle> Garage { get => garage; protected set => garage = value; }

        public Vehicle GetVehicle (int garageSlot)
        {
            if (garageSlot >= GarageSlots)
            
                throw new InvalidOperationException("Invalid Garage Slot");
                
            else if (Garage[garageSlot] == null)
                throw new InvalidOperationException("No Vehicle is the Garage Slot");
            else
                return Garage[garageSlot];

        }

            
            public int SendVehicleTo(int garageSlot,Storage deliveryLocation)
            {
                Vehicle v = GetVehicle(garageSlot);
            if (deliveryLocation.garage.Count < deliveryLocation.GarageSlots)
                deliveryLocation.garage.Add(v);


            else
                throw new InvalidOperationException("No room in garage.");
                return deliveryLocation.garage.Count;
            }

        public int UnloadVehicle(int garageSlot)
        {
            if (IsFull)
                throw new InvalidOperationException("Storage is full");
            var v = GetVehicle(garageSlot);
            int unloaded = 0;
            foreach (Product product in v.Trunk)
            {
               
                if (!v.IsEmpty || !this.IsFull)

                    this.products.Add(product);
                v.UnLoad(product);
                
                unloaded ++;
            }
            return unloaded;
        }
    }
   
   
    



}

