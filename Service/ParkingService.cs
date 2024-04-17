using System;
using System.Collections.Generic;

public class ParkingService : IParkingService
{
    private int _initSlot;
    private ParkingLot[] _parkingLots;

    public ParkingService()
    {
        _initSlot = 0;
        _parkingLots = new ParkingLot[_initSlot];
    }

    public void SetSlot(int slot)
    {
        _initSlot = slot;
        _parkingLots = new ParkingLot[_initSlot];
        Console.WriteLine($"Created a parking lot with {slot} slots");
    }

    public void Color(string color)
    {
        var isFirstValue = true;
        foreach (var t in _parkingLots)
        {
            if (t.Vehicle.Color.ToLower() == color)
            {
                if (isFirstValue)
                {
                    isFirstValue = false;
                }
                else
                {
                    Console.Write(", ");
                }

                Console.Write(t.Vehicle.LicensePlate);
            }
        }

        Console.WriteLine();
    }

    public void EvenPlate()
    {
        var isFirstValue = true;
        for (var i = 0; i < _parkingLots.Length; i++)
        {
            var plate = _parkingLots[i].Vehicle.LicensePlate.Split("-");
            if (Convert.ToInt32(plate[1]) % 2 == 0)
            {
                if (isFirstValue)
                {
                    isFirstValue = false;
                }
                else
                {
                    Console.Write(", ");
                }
                Console.Write($"{_parkingLots[i].Vehicle.LicensePlate}");
            }
        }

        Console.WriteLine();
    }

    public void Leave(int number)
    {
        var index = number - 1;
        if (index < _parkingLots.Length && index >= 0)
        {
            _parkingLots[index] = null;
        }

        Console.WriteLine($"Slot number {number} is free");
    }

    public void OddPlate()
    {
        for (var i = 0; i < _parkingLots.Length; i++)
        {
            var plate = _parkingLots[i].Vehicle.LicensePlate.Split("-");
            if (Convert.ToInt32(plate[1]) % 2 != 0)
            {
                if (i == _parkingLots.Length - 1)
                {
                    Console.Write($"{_parkingLots[i].Vehicle.LicensePlate} \n");
                }
                else
                {
                    Console.Write($"{_parkingLots[i].Vehicle.LicensePlate}, ");
                }
            }
        }
    }

    public void Park(ParkingLot parkingLot)
    {
        for (var i = 0; i < _parkingLots.Length; i++)
        {
            if (_parkingLots[i] == null)
            {
                _parkingLots[i] = new ParkingLot
                {
                    Slot = parkingLot.Slot,
                    Remaining = parkingLot.Remaining,
                    Vehicle = parkingLot.Vehicle
                };
                System.Console.WriteLine("Allocated slot number: " + (i + 1));
                return;
            }
        }

        System.Console.WriteLine("Sorry, parking lot is full");
    }


    public void SlotPlate(string plate)
    {
        var isTrue = true;
        for (var i = 0; i < _parkingLots.Length; i++)
        {
            if (_parkingLots[i].Vehicle.LicensePlate == plate) 
            {
                Console.WriteLine(i+1);
                isTrue = false;
            }
        }

        if (isTrue) Console.WriteLine("Not Found");
    }

    public void SlotWithColor(string color)
    {
        var found = false;
        for (var i = 0; i < _parkingLots.Length; i++)
        {
            if (string.Equals(_parkingLots[i].Vehicle.Color, color, StringComparison.OrdinalIgnoreCase))
            {
                if (found)
                {
                    Console.Write(", ");
                }

                Console.Write(i + 1);
                found = true;
            }
        }

        if (found)
        {
            Console.WriteLine();
        }
    }

    public void Status()
    {
        Console.WriteLine($"Slot        No.         Type        Registration No Color");
        for (var i = 0; i < _parkingLots.Length; i++)
        {
            if (_parkingLots[i] == null) continue;
            Console.WriteLine(
                $"{i + 1}       {_parkingLots[i].Vehicle.LicensePlate}      {_parkingLots[i].Vehicle.Type}              {_parkingLots[i].Vehicle.Color}");
        }
    }

    public void TypeOf(string type)
    {
        var countMotor = 0;
        var countMobil = 0;
        foreach (var parkingLot in _parkingLots)
        {
            if (parkingLot.Vehicle.Type.ToLower() == type)
            {
                countMotor++;
            }

            if (parkingLot.Vehicle.Type.ToLower() == type)
            {
                countMobil++;
            }
        }

        string result = (type == "motor") ? $"{countMotor}" : $"{countMobil}";
        Console.WriteLine(result);
    }
}