using System;

namespace Parking_Lot.Exceptions
{
    public class NoFreeSlotAvailableException : Exception
    {
        public NoFreeSlotAvailableException(string message) : base(message)
        {
        }
    }
}
