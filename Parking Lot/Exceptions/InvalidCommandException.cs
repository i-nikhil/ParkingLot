using System;

namespace Parking_Lot.Exceptions
{
    public class InvalidCommandException : Exception
    {
        public InvalidCommandException(string message) : base(message)
        {
        }
    }
}
