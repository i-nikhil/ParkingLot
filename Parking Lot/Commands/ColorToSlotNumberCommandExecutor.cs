using Parking_Lot.Model;
using Parking_Lot.Service;
using System;
using System.Collections.Generic;

namespace Parking_Lot.Commands
{
    public class ColorToSlotNumberCommandExecutor : CommandExecutor
    {
        public static readonly string CommandName = "slot_numbers_for_cars_with_colour";
        public ColorToSlotNumberCommandExecutor(ParkingLotService service) : base(service)
        {
        }

        public override bool Validate(Command command)
        {
            return command.parameters.Length == 1;
        }

        public override void Execute(Command command)
        {
            IList<int> slotNumbers = parkingLotService.GetSlotNumbersForCarsWithColor(command.parameters[0]);
            Console.WriteLine(string.Join(", ", slotNumbers));
        }
    }
}