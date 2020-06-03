using StorageMaster.Models.Products;
using System;
using System.Collections.Generic;
using System.Text;

namespace StorageMaster.Models.Vehicles
{
    public abstract class Vehicle
    {
        private double capacity;
        private List<Product> trunk;
        private bool isFull;
        private bool isEmpty;

        protected Vehicle(int capacity)
        {
            Capacity = capacity;
            Trunk = new List<Product>();
        }

        public double Capacity { get => capacity; set => capacity = value; }
        public List<Product> Trunk { get => trunk; private set => trunk = value; }
        public bool IsFull
        {
            get
            {
                double sumWeight = 0;
                foreach (Product product in Trunk)
                {
                    sumWeight += product.Weight;
                }
                if (sumWeight >= capacity)
                    this.isFull = true;
                return isFull;
            }

        }
        public bool IsEmpty
        {
            get
            {
                if (Trunk.Count == 0)
                    isEmpty = true;
                return isEmpty;
            }

        }
        public override string ToString()
        {
            return "";
        }

        /// <summary>
        /// if the vehicle is not full, a product is added
        /// </summary>
        /// <param name="product"></param>
        public void LoadProduct(Product product)
        {
            if (isFull)
                throw new InvalidOperationException("Vehicle is full.");
            else
                Trunk.Add(product);
        }
        /// <summary>
        /// if the vehicle is not empty, the last product in the list Trunk is removed
        /// </summary>
        /// <param name="product"></param>
        public void UnLoad(Product product)
        {
            if (isEmpty)
                throw new InvalidOperationException("No products left in vehicle.");
            else
                trunk.Remove(product);
            //maybe bound error, trunk.Count -1
            capacity = capacity - product.Weight;
        }
    }
}
