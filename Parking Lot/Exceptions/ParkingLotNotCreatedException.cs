using System;

namespace Parking_Lot.Exceptions
{
    public class ParkingLotNotCreatedException : Exception
    {
        public ParkingLotNotCreatedException(string message) : base(message)
        {
        }
    }
}
