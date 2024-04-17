using System;
using System.Collections.Generic;

public class Menu
{
    public void Show()
    {
        ParkingLot parkingLot = new ParkingLot();
        ParkingService service = new ParkingService();
        while (true)
        {
            System.Console.Write("$ ");
            var input = System.Console.ReadLine();
            input.ToLower();
            if (input.Contains("create"))
            {
                var value = input.Split(" ");
                parkingLot.Slot = Convert.ToInt32(value[1]);
                parkingLot.Remaining = parkingLot.Slot;
                service.SetSlot(parkingLot.Slot);
            }
            else if (input.Contains("park"))
            {
                var value = input.Split(" ");
                var vehicle = new Vehicle
                {
                    LicensePlate = value[1],
                    Color = value[2],
                    Type = value[3]
                };
                parkingLot.Vehicle = vehicle;

                service.Park(parkingLot);
                if (parkingLot.Remaining != 0)
                {
                    parkingLot.Remaining -= 1;
                }
            }
            else if (input.Contains("leave"))
            {
                var value = input.Split(" ");
                service.Leave(Convert.ToInt32(value[1]));
                parkingLot.Remaining += 1;
            }
            else if (input.Contains("status"))
            {
               service.Status();
            }
            else if (input.Contains("type"))
            {
                var value = input.Split(" ");
                service.TypeOf(value[1].ToLower());
            }
            else if (input.Contains("odd"))
            {
                service.OddPlate();
            }
            else if (input.Contains("even"))
            {
                service.EvenPlate();
            }
            else if (input.Contains("registration_numbers_for_vehicles_with_colour"))
            {
                var value = input.Split(" ");
                service.Color(value[1].ToLower());
            } else if (input.Contains("slot_numbers_for_vehicles_with_colour"))
            {
                var value = input.Split(" ");
                service.SlotWithColor(value[1].ToLower());
            }
            else if (input.Contains("slot_number_for_registration_number"))
            {
                var value = input.Split(" ");
                service.SlotPlate(value[1]);
            }
            else if (input.Contains("exit"))
            {
                return;
            }
        }
    }
}