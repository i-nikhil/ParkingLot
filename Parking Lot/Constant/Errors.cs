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
    }
}