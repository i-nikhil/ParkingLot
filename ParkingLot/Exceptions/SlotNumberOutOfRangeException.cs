using System;

namespace Parking_Lot.Exceptions
{
    public class SlotNumberOutOfRangeException : Exception
    {
        public SlotNumberOutOfRangeException(string message) : base(message)
        {
        }
    }
}