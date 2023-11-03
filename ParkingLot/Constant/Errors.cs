namespace Parking_Lot.Constant
{
    public static class Errors
    {
        public static readonly string InvalidInputMode = "Input Mode is invalid";
        public static readonly string InvalidCommand = "Command is invalid";
        public static readonly string InvalidParkingLotCapacity = "Number of slots can not be negative or zero";
        public static readonly string ParkingLotAlreadyCreated = "Parking lot is already created with {0} slots";
        public static readonly string ParkingLotNotCreated = "Create a Parking Lot first, using command: 'create_parking_lot <number of slots>'";
        public static readonly string CarAlreadyParked = "Car with registration number {0} is already parked in slot {1}";
        public static readonly string NoFreeSlotAvailable = "Sorry, parking lot is full";
        public static readonly string ParkingSlotEmpty = "No car present in parking slot {0}";
        public static readonly string SlotNumberOutOfRange = "Slot number must be within 1 and {0}";
        public static readonly string NoCarsParked = "No cars present in parking lot at the moment";
        public static readonly string NoMatchingColorCarFound = "No cars found with the color {0}";
        public static readonly string CarNotFound = "Not found";
    }
}