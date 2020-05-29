using System;

namespace StorageMaster.Models.Products
{
    public abstract class Product
    {
        private double price;
        private double weight;

        public Product(double price, double weight)
        {
            Price = price;
            Weight = weight;
        }

        public double Price
        {
            get => price;
            set
            {
                if (price < 0)
                {
                    throw new InvalidOperationException("Price cannot be negative!");
                }
                price = value;
            }
        }
        public double Weight { get => weight; set => weight = value; }
    }
}
