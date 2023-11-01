using Parking_Lot.Constant;
using Parking_Lot.Exceptions;
using Parking_Lot.Model;
using System.Collections.Generic;
using System.Linq;

namespace Parking_Lot.Service
{
    public class ParkingLotService
    {
        private ParkingLot parkingLot;

        /// <summary>
        /// Creates a new Parking lots with specified number of vacant slots
        /// </summary>
        /// <param name="capacity"></param>
        public void CreateparkingLot(int capacity)
        {
            //Check if parking lot is already created
            if (parkingLot != null)
            {
                throw new ParkingLotAlreadyCreatedException(string.Format(Errors.ParkingLotAlreadyCreated, parkingLot.Capacity));
            }

            //Create new parking lot
            parkingLot = new ParkingLot(capacity);
        }

        /// <summary>
        /// Parks the car and returns the alotted slot number
        /// </summary>
        /// <param name="car"></param>
        /// <returns></returns>
        /// <exception cref="ParkingLotNotCreatedException"></exception>
        /// <exception cref="CarAlreadyParkedException"></exception>
        /// <exception cref="NoFreeSlotAvailableException"></exception>
        public int Park(Car car)
        {
            //Check if the parking lot is created
            if (parkingLot == null)
            {
                throw new ParkingLotNotCreatedException(Errors.ParkingLotNotCreated);
            }

            //Check if the car is already parked in the parking lot
            foreach (KeyValuePair<int, Car> slot in parkingLot.Slots)
            {
                if (slot.Value != null && slot.Value.RegistrationNumber.Equals(car.RegistrationNumber))
                {
                    throw new CarAlreadyParkedException(string.Format(Errors.CarAlreadyParked, slot.Value.RegistrationNumber, slot.Key));
                }
            }

            //Check if any slot is empty for parking
            if (!parkingLot.Slots.ContainsValue(null))
            {
                throw new NoFreeSlotAvailableException(Errors.NoFreeSlotAvailable);
            }

            //Find the closest empty slot for parking
            int closestEmptySlot = parkingLot.Slots.FirstOrDefault(slot => slot.Value is null).Key;

            //Park the car
            parkingLot.Slots[closestEmptySlot] = car;
            return closestEmptySlot;
        }
    }
}