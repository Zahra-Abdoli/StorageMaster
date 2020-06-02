using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using StorageMaster.Models.Vehicles;

namespace StorageMaster.IO
{
    public class Cosole
    {
           public static void Start()
            {
                Console.WriteLine("StorageMaster\n");

            // Main menu
            while (true)
            {
                Console.WriteLine(
                "Main menu\n" +
                "1.Add product, push 1\n" +
                "2.Register a new storage, push 2\n" +
                "3.Select a vehicle, push 3\n" +
                "4.Load vehicle, push 4\n" +
                "5.Send vehicle to storage, push 5\n" +
                "6.Unload vehicle, push 6\n" +
                "7.Get storage status, push 7\n" +
                "To close program, enter End\n"
                );

                string menuChoice = Console.ReadLine();

                //try
                //{
                switch (menuChoice)
                {
                    //AddProduct()
                    case "1":
                        Console.WriteLine("What type of product do you want to ad to the product pool? : ");
                        string productType = Console.ReadLine().ToLower();

                        Console.WriteLine("What is the products price? : ");
                        double price = Convert.ToDouble(Console.ReadLine());


                        core.StorageMaster.AddProduct(productType, price);
                        Console.WriteLine($"{productType} added");
                        break;

                    //RegisterStorage()
                    case "2":
                        Console.WriteLine("What type of storage do you want to register? : ");
                        string storageType = Console.ReadLine().ToLower();

                        Console.WriteLine("Enter a name for the storage : ");
                        string storageName = Console.ReadLine().ToLower();

                        core.StorageMaster.RegisterStorage(storageType, storageName);
                        break;

                    //SelectVehicle()
                    case "3":
                        Console.WriteLine("What is the name of the storage you want to get the vehicle from? : ");
                        string storeName = Console.ReadLine().ToLower();

                        Console.WriteLine("In what garage slot is the vehicle parked? : ");
                        int garageSlot = Convert.ToInt32(Console.ReadLine());

                        core.StorageMaster.SelectedVehicle(storeName, garageSlot);
                        break;

                    //LoadVehicle()
                    case "4":

                        Console.WriteLine("What is the name of the storage where the vehicle is parked? : ");
                        string sName = Console.ReadLine().ToLower();

                        Console.WriteLine("In what parking slot is the vehicle you want to load? : ");
                        int parkSlot = Convert.ToInt32(Console.ReadLine());

                        Vehicle vehicle = core.StorageMaster.StorageRegistary.Where(p => p.Name == sName).First().GetVehicle(parkSlot); ;

                        Console.WriteLine("How many products do you want to load? : ");
                        string stringNrOfProducts = Console.ReadLine();
                        int numberOfProducts = Convert.ToInt32(stringNrOfProducts);

                        List<string> productNames = new List<string>();

                        for (int i = 1; i < numberOfProducts + 1; i++)
                        {
                            Console.WriteLine("What is the name of product " + (i) + "? : ");
                            string prodName = Console.ReadLine().Trim();
                            ////make the first letter capital
                            prodName=prodName.First().ToString().ToUpper()+prodName.Substring(1);
                            productNames.Add(prodName);
                        }

                        core.StorageMaster.LoadVehicle(productNames, vehicle);
                        break;

                    //SendVehicleTo()
                    case "5":
                        Console.WriteLine("What is the name of the storage you want to get the vehicle from? : ");
                        string sourceName = Console.ReadLine().ToLower();

                        Console.WriteLine("What slot is the vehicle parked? : ");
                        int slot = Convert.ToInt32(Console.ReadLine());

                        Console.WriteLine("What is the name of the storage you want to send the vehicle? : ");
                        string destinationName = Console.ReadLine();

                        core.StorageMaster.SendVehicleTo(sourceName, slot, destinationName);
                        break;

                    //UnLoadVehicle()
                    case "6":
                        Console.WriteLine("What is the name of the storage where the vehicle is parked? : ");
                        string stName = Console.ReadLine().ToLower();

                        Console.WriteLine("What slot is the vehicle parked? : ");
                        int slo = Convert.ToInt32(Console.ReadLine());

                        core.StorageMaster.UnloadVehicle(stName, slo);
                        break;

                    //GetStorageStatus()
                    case "7":
                        Console.WriteLine("What is the name of the storage you want the storage status? : ");
                        string store = Console.ReadLine().ToLower();

                        core.StorageMaster.GetStorageStatuse(store);
                        break;

                    //quit
                    case "End":
                        core.StorageMaster.GetSummary();

                        Console.WriteLine("To quit, press 0");
                        Environment.Exit(0);
                        break;

                    // default, when input in menu is not valid
                    default:
                        Console.WriteLine(
                            "\nUnvalid choice\n" +
                            "Choose from the main menu options\n");
                        break;
                }
            }
                    //catch (InvalidOperationException ie)
                    //{
                    //    throw new InvalidOperationException("Error: ", ie);
                    //}
                }
            }
        }
    //}k

