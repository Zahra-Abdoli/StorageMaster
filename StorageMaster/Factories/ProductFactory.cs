using System;
using System.Collections.Generic;
using System.Text;
using StorageMaster.Models.Products;

namespace StorageMaster.Factories

{ 
 public static class ProductFactory
    {
        public static Product CreateProduct(string type, double price)
        {
            Product product;
            switch (type)
            {
                case "gpu":
                    product = new Gpu(price);
                    break;


                case "harddrive":
                    product = new HardDrive(price);
                    break;


                case "ram":
                    product = new Ram(price);
                    break;
                case "solidstatedrive":
                    product = new SolidStateDrive(price);
                    break;
                default:
                    throw new InvalidOperationException("Invalid product type!");
            }
            return product;
        }
    }





}
