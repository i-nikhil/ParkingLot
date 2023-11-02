using Parking_Lot.Model;
using Parking_Lot.Service;
using System;
using System.Collections.Generic;

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
            int slotNumber = parkingLotService.GetSlotNumberForCarsWithRegistrationNumber(command.parameters[0]);
            Console.WriteLine(slotNumber);
        }
    }
}