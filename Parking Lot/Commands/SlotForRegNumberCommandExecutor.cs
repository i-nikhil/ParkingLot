using Parking_Lot.Model;
using Parking_Lot.Service;
using System;

namespace Parking_Lot.Commands
{
    public class SlotForRegNumberCommandExecutor : CommandExecutor
    {
        public static readonly string CommandName = "slot_number_for_registration_number";

        public SlotForRegNumberCommandExecutor(ParkingLotService service) : base(service)
        {
        }

        public override bool Validate(Command command)
        {
            return command.parameters.Length == 1;
        }

        public override void Execute(Command command)
        {
            throw new NotImplementedException();
        }
    }
}