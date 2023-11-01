using Parking_Lot.Model;
using Parking_Lot.Service;
using System;
using System.Linq;

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
            throw new NotImplementedException();
        }
    }
}
