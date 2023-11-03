using Parking_Lot.Model;
using Parking_Lot.Service;
using System;

namespace Parking_Lot.Commands
{
    public class ExitCommandExecutor : CommandExecutor
    {
        public static readonly string CommandName = "exit";

        public ExitCommandExecutor(ParkingLotService service) : base(service)
        {
        }

        public override bool Validate(Command command)
        {
            return command.parameters.Length == 0;
        }

        public override void Execute(Command command)
        {
            Environment.Exit(0);
        }
    }
}