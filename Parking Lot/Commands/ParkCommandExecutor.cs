using Parking_Lot.Constant;
using Parking_Lot.Model;
using Parking_Lot.Service;
using System;

namespace Parking_Lot.Commands
{
    public class ParkCommandExecutor : CommandExecutor
    {
        public static readonly string CommandName = "park";

        public ParkCommandExecutor(ParkingLotService service) : base(service)
        {
        }

        public override bool Validate(Command command)
        {
            return command.parameters.Length == 2;
        }

        public override void Execute(Command command)
        {
            Car car = new Car(command.parameters[0], command.parameters[1]);
            int slotAlloted = parkingLotService.Park(car);

            Console.WriteLine(string.Format(Messages.CarParked, slotAlloted));
        }
    }
}