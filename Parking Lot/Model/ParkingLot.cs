using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parking_Lot.Model
{
    public class ParkingLot
    {
        public int Capacity { get; private set; }
        
        //Mapping between slot number and the car's registration number
        public Dictionary<int, string> Slots { get; private set; }

        public ParkingLot(int capacity)
        {
            Slots = new Dictionary<int, string>(capacity);
        }
    }
}
