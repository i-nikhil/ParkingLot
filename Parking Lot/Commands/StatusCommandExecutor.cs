using Parking_Lot.Model;
using Parking_Lot.Service;
using System;

namespace Parking_Lot.Commands
{
    public class StatusCommandExecutor : CommandExecutor
    {
        public static readonly string CommandName = "status";

        public StatusCommandExecutor(ParkingLotService service) : base(service)
        {
        }

        public override bool Validate(Command command)
        {
            return command.parameters.Length == 0;
        }

        public override void Execute(Command command)
        {
            throw new NotImplementedException();
        }
    }
}
