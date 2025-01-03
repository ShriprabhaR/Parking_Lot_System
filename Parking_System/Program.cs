using System;

namespace Parking_System
{
    internal class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("\nParking System Menu:");
                Console.WriteLine("1. Check lot status");
                Console.WriteLine("2. Handicap or not");
                Console.WriteLine("3. Park a Vehicle");
                Console.WriteLine("4. Find a vehicle");
                Console.WriteLine("5. Unpark a Vehicle");

                Console.WriteLine("Enter your choice:");
                int choice = int.Parse(Console.ReadLine());


                switch (choice)
                {
                    case 1:
                        Console.WriteLine(ParkingLot.CheckLotStatus());
                        break;

                    case 2:
                        ParkingLot.Handicap();
                        break;

                    case 3:
                        ParkingLot.ParkVehicle();
                        break;

                    case 4:
                        ParkingLot.FindVehicle();
                        break;

                    case 5:
                        ParkingLot.UnparkVehicle();
                        break;

                    default:
                        Console.WriteLine("Invalid choice. Please try again.");
                        break;

                }
            }

        }
    }
}
