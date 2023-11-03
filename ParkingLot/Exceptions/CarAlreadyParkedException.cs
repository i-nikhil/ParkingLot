using System;

namespace Parking_Lot.Exceptions
{
    public class CarAlreadyParkedException : Exception
    {
        public CarAlreadyParkedException(string message) : base(message)
        {
        }
    }
}
