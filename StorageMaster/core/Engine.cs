using System;
using System.Collections.Generic;
using System.Text;

namespace StorageMaster.core
{
    public class Engine
    {

        private string result;


        //public Engine(StorageMaster storageMaster)
        //{
        //    this.storageMaster = storageMaster;
        //}


        public void RunEngine()
        {
            while (true)
            {
                string end = Console.ReadLine().ToLower();
                if (end == "end")
                    break;

                string[] input = end.Split(' ');

                try
                {
                    switch (input[0])
                    {
                        case "addproduct":
                            result += "\n" + StorageMaster.AddProduct(input[1], double.Parse(input[2]));
                            break;
                        case "registerstorage":
                            result += "\n" + StorageMaster.RegisterStorage(input[1], input[2]);
                            break;


                        case "selectedvehicle":
                            result += "\n" + StorageMaster.SelectedVehicle(input[1], int.Parse(input[2]));
                            break;


                        case "loadvehicle":
                            //result = StorageMaster.LoadVehicle(input.Skip(1).ToList());
                            break;


                        case "sendvehicleto":
                            result += "\n" + StorageMaster.SendVehicleTo(input[1], int.Parse(input[2]), input[3]);
                            break;


                        case "unloadvehicle":
                            result +="\n"+ StorageMaster.UnloadVehicle(input[1], int.Parse(input[2]));
                            break;


                        case "getstoragestatuse":
                            result += "\n" + StorageMaster.GetStorageStatuse(input[1]);
                            break;
                    }

                }
                catch (InvalidOperationException e)
                {
                    result += $"\n Error:   {e.Message}";
                }
            }

            Console.WriteLine(result);
            Console.WriteLine(StorageMaster.GetSummary());
        }
    }
}

