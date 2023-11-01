using Parking_Lot.Model;
using Parking_Lot.Service;
using System;
using System.Linq;

namespace Parking_Lot.Commands
{
    public class LeaveCommandExecutor : CommandExecutor
    {
        public static readonly string CommandName = "leave";

        public LeaveCommandExecutor(ParkingLotService service) : base(service)
        {
        }
        
        public override bool Validate(Command command)
        {
            if (command.parameters.Length != 1)
            {
                return false;
            }

            return int.TryParse(command.parameters.FirstOrDefault(), out _);
        }

        public override void Execute(Command command)
        {
            throw new NotImplementedException();
        }
    }
}
