using System;

namespace Parking_Lot.Exceptions
{
    public class ParkingSlotEmptyException : Exception
    {
        public ParkingSlotEmptyException(string message) : base(message)
        {
        }
    }
}