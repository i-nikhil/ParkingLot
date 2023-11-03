using System;

namespace Parking_Lot.Exceptions
{
    public class InvalidModeException : Exception
    {
        public InvalidModeException(string message) : base(message)
        {
        }
    }
}
