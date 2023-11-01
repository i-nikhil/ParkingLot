﻿using Parking_Lot.Model;
using Parking_Lot.Service;
using System;

namespace Parking_Lot.Commands
{
    public class ColorToRegNumberCommandExecutor : CommandExecutor
    {
        public static readonly string CommandName = "registration_numbers_for_cars_with_colour";

        public ColorToRegNumberCommandExecutor(ParkingLotService service) : base(service)
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
