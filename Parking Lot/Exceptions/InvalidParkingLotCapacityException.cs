using System;

namespace Parking_Lot.Exceptions
{
    public class InvalidParkingLotCapacityException : Exception
    {
        public InvalidParkingLotCapacityException(string message) : base(message)
        {
        }
    }
}
