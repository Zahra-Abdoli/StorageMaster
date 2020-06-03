using System;
using System.Collections.Generic;
using System.Text;
using StorageMaster.Models.Storage;

namespace StorageMaster.Factories
{
   public static class StorageFactory

    { 
            public static Storage CreateStorage(string type, string name)
            {
                Storage storage;
                switch (type)
                {
                    case "automatedwarehouse":
                        storage = new AutomatedWarehouse(name);
                        break;
                    case "distributioncenter":
                        storage = new DistributionCenter(name);
                        break;
                    case "warehouse":
                        storage = new Warehouse(name);
                        break;


                    default:
                        throw new InvalidOperationException("Invalid storage type!");
                }
                return storage;


            }


        }
    }








