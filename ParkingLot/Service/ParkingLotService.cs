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
        /// <param name="capacity">Total number of parking slots to be created</param>
        /// <exception cref="ParkingLotAlreadyCreatedException"></exception>
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
        /// <param name="registrationNumber">Registration number of the car</param>
        /// <param name="color">Color of the car</param>
        /// <returns>Alloted parking slot number</returns>
        /// <exception cref="ParkingLotNotCreatedException"></exception>
        /// <exception cref="CarAlreadyParkedException"></exception>
        /// <exception cref="NoFreeSlotAvailableException"></exception>
        public int ParkCar(string registrationNumber, string color)
        {
            //Check if the parking lot is created
            if (parkingLot == null)
            {
                throw new ParkingLotNotCreatedException(Errors.ParkingLotNotCreated);
            }

            //Check if the car is already parked in the parking lot
            foreach (KeyValuePair<int, Car> slot in parkingLot.Slots)
            {
                if (slot.Value != null && slot.Value.RegistrationNumber.Equals(registrationNumber))
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

            //ParkCar the car
            parkingLot.Slots[closestEmptySlot] = new Car(registrationNumber, color);
            return closestEmptySlot;
        }

        /// <summary>
        /// Remove the car in parking slot
        /// </summary>
        /// <param name="slotNumber">Slot number to be vacated</param>
        /// <exception cref="ParkingLotNotCreatedException"></exception>
        /// <exception cref="SlotNumberOutOfRangeException"></exception>
        /// <exception cref="ParkingSlotEmptyException"></exception>
        public void RemoveCar(int slotNumber)
        {
            //Check if the parking lot is created
            if (parkingLot == null)
            {
                throw new ParkingLotNotCreatedException(Errors.ParkingLotNotCreated);
            }

            //Check if slot number is in range
            if (slotNumber < 1 || slotNumber > parkingLot.Capacity)
            {
                throw new SlotNumberOutOfRangeException(string.Format(Errors.SlotNumberOutOfRange, parkingLot.Capacity));
            }

            //Check if the slot is already empty
            if (parkingLot.Slots[slotNumber] == null)
            {
                throw new ParkingSlotEmptyException(string.Format(Errors.ParkingSlotEmpty, slotNumber));
            }

            //Vacate the parking slot
            parkingLot.Slots[slotNumber] = null;
        }

        /// <summary>
        /// Get the list of all car's details parked at the moment
        /// </summary>
        /// <returns>Occupied slot numbers and car details</returns>
        /// <exception cref="ParkingLotNotCreatedException"></exception>
        /// <exception cref="ParkingSlotEmptyException"></exception>
        public Dictionary<int, Car> GetOccupiedSlotDetails()
        {
            //Check if the parking lot is created
            if (parkingLot == null)
            {
                throw new ParkingLotNotCreatedException(Errors.ParkingLotNotCreated);
            }

            //Check if parking lot is empty
            if (!parkingLot.Slots.Values.Any(car => car != null))
            {
                throw new ParkingSlotEmptyException(Errors.NoCarsParked);
            }

            //Filter out the occupied slots
            Dictionary<int, Car> occupiedSlots = new Dictionary<int, Car>();

            foreach (KeyValuePair<int, Car> slot in parkingLot.Slots)
            {
                if (slot.Value != null)
                {
                    occupiedSlots.Add(slot.Key, slot.Value);
                }
            }

            //Return the occupied slot details
            return occupiedSlots;
        }

        /// <summary>
        /// Get registration numbers for cars with specific color
        /// </summary>
        /// <param name="color">Color of cars to be found</param>
        /// <returns>Matching car's registration number</returns>
        /// <exception cref="CarNotFoundException"></exception>
        public IList<string> GetRegistrationNumbersForCarsWithColor(string color)
        {
            //Get occupied parking slots
            Dictionary<int, Car> occupiedSlots = GetOccupiedSlotDetails();

            //Filter registration numbers by color
            List<string> registrationNumbers = occupiedSlots.Values.Where(car => car.Color.Equals(color)).Select(car => car.RegistrationNumber).ToList();

            //If no matching color car found
            if (!registrationNumbers.Any())
            {
                throw new CarNotFoundException(string.Format(Errors.NoMatchingColorCarFound, color));
            }

            //Return filtered list
            return registrationNumbers;
        }

        /// <summary>
        /// Get slot numbers for cars with specific color
        /// </summary>
        /// <param name="color">Color of cars to be found</param>
        /// <returns>Matching car's slot number</returns>
        /// <exception cref="CarNotFoundException"></exception>
        public IList<int> GetSlotNumbersForCarsWithColor(string color)
        {
            //Get occupied parking slots
            Dictionary<int, Car> occupiedSlots = GetOccupiedSlotDetails();

            //Filter parking slot numbers by color
            List<int> slotNumbers = occupiedSlots.Where(slot => slot.Value.Color.Equals(color)).Select(slot => slot.Key).ToList();

            //If no matching color car found
            if (!slotNumbers.Any())
            {
                throw new CarNotFoundException(string.Format(Errors.NoMatchingColorCarFound, color));
            }

            //Return filtered list
            return slotNumbers;
        }

        /// <summary>
        /// Get slot number for cars with specfic registration number
        /// </summary>
        /// <param name="registrationNumber">Car's registration number</param>
        /// <returns>Slot number in which the car is parked</returns>
        /// <exception cref="CarNotFoundException"></exception>
        public int GetSlotNumberForCarsWithRegistrationNumber(string registrationNumber)
        {
            //Get occupied parking slots
            Dictionary<int, Car> occupiedSlots = GetOccupiedSlotDetails();

            //Find parking slot number for registration number
            int slotNumber = occupiedSlots.FirstOrDefault(slot => slot.Value.RegistrationNumber.Equals(registrationNumber)).Key;

            //If car not present in any slot
            if (slotNumber is 0)
            {
                throw new CarNotFoundException(Errors.CarNotFound);
            }

            //Return slot number
            return slotNumber;
        }
    }
}