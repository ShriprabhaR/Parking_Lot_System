using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace Parking_System
{
    
    internal class ParkingLot
    {
        public static int LotCapacity = 100;
        public static int CurrentCount = 0;
        static Dictionary<string, Vehicle> parkedVehicles = new Dictionary<string, Vehicle>();


        public static string CheckLotStatus()
        {
            return CurrentCount >= LotCapacity ? "Parking lot is full" : "Parking lot has available spaces.";
        }

        public static void Handicap()
        {
            Console.WriteLine("Are you Handicap Person? Enter Yes or No");
            string handicap = Console.ReadLine();
            if (handicap == "Yes")
            {
                Console.WriteLine("Valet service provided for handicapped driver.");
            }
            else if(handicap == "No")
            {
                Console.WriteLine("you can Park you car if slot is empty");
            }
           
        }

        public static void ParkVehicle()
        { 
          if (CurrentCount >= LotCapacity)
          {
            Console.WriteLine("Parking lot is full. Cannot park more vehicles.");
            return;
          }


          Console.WriteLine("Enter Vehicle Number Plate:");
          string numberPlate = Console.ReadLine();

          Console.WriteLine("Enter Owner's Name:");
          string ownerName = Console.ReadLine();

          Console.WriteLine("Enter Vehicle Size (Small/Large):");
          string size = Console.ReadLine();

          Vehicle vehicle = new Vehicle
          {
             NumberPlate = numberPlate,
             OwnerName = ownerName,
             Size = size,
             ParkedTime = DateTime.Now
          };

           parkedVehicles[numberPlate] = vehicle;
           CurrentCount++;

           Console.WriteLine($"Vehicle {numberPlate} parked successfully.");
        }

        public static void FindVehicle()
        {
            Console.WriteLine("Enter Vehicle Number Plate to Find:");
            string numberPlate = Console.ReadLine();

            if (parkedVehicles.ContainsKey(numberPlate))
            {
                Console.WriteLine($"Vehicle {numberPlate} is parked in the lot.");
            }
            else
            {
                Console.WriteLine("Vehicle not found.");
            }
        }

        public static void UnparkVehicle()
        {
            Console.WriteLine("Enter Vehicle Number Plate to Unpark:");
            string numberPlate = Console.ReadLine();

            if (!parkedVehicles.ContainsKey(numberPlate))
            {
                Console.WriteLine("Vehicle not found in the parking lot.");
                return;
            }

            Vehicle vehicle = parkedVehicles[numberPlate];
            parkedVehicles.Remove(numberPlate);
            CurrentCount--;

            TimeSpan duration = DateTime.Now - vehicle.ParkedTime;
            double charges = CalculateCharges(duration);

            Console.WriteLine($"Vehicle {numberPlate} unparked successfully.");
            Console.WriteLine($"Parking Duration: {duration.TotalMinutes} minutes. Charges: ₹{charges}");
        }

        private static double CalculateCharges(TimeSpan duration)
        {
            int fullHours = (int)duration.TotalHours; 
            int remainingMinutes = duration.Minutes; 

            double charges = fullHours * 20; 
            if (remainingMinutes > 0) 
            {
                charges = charges + 20;
            }

            return charges;
        }




        






    }
}
