using Parking_Lot.Constant;
using Parking_Lot.Exceptions;
using System.Collections.Generic;

namespace Parking_Lot.Model
{
    public class ParkingLot
    {
        public int Capacity { get; private set; }

        //Mapping between slot number and the car
        public Dictionary<int, Car> Slots { get; private set; }

        public ParkingLot(int capacity)
        {
            if (capacity <= 0)
            {
                throw new InvalidParkingLotCapacityException(Errors.InvalidParkingLotCapacity);
            }

            Capacity = capacity;
            Slots = new Dictionary<int, Car>(capacity);

            for (int slotIndex = 1; slotIndex <= capacity; slotIndex++)
            {
                Slots.Add(slotIndex, null);
            }
        }
    }
}