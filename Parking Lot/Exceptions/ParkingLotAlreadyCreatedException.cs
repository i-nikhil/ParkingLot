using System;

namespace Parking_Lot.Exceptions
{
    public class ParkingLotAlreadyCreatedException : Exception
    {
        public ParkingLotAlreadyCreatedException(string message) : base(message)
        {
        }
    }
}
