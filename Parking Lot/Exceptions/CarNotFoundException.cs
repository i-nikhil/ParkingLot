using System;

namespace Parking_Lot.Exceptions
{
    public class CarNotFoundException : Exception
    {
        public CarNotFoundException(string message) : base(message)
        {
        }
    }
}