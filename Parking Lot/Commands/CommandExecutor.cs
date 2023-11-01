using Parking_Lot.Model;
using Parking_Lot.Service;

namespace Parking_Lot.Commands
{
    public abstract class CommandExecutor
    {
        private readonly ParkingLotService parkingLotService;

        public CommandExecutor(ParkingLotService service)
        {
            parkingLotService = service;
        }

        public abstract bool Validate(Command command);

        public abstract void Execute(Command command);
    }
}
