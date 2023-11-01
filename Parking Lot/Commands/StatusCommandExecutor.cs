using Parking_Lot.Constant;
using Parking_Lot.Model;
using Parking_Lot.Service;
using System;
using System.Collections.Generic;

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
            Dictionary<int, Car> occupiedSlots = parkingLotService.GetOccupiedSlotDetails();

            Console.WriteLine(Messages.StatusListHeadings);
            foreach (KeyValuePair<int, Car> slot in occupiedSlots)
            {
                Console.WriteLine($"{slot.Key}        {slot.Value.RegistrationNumber}   {slot.Value.Color}");
            }
        }
    }
}