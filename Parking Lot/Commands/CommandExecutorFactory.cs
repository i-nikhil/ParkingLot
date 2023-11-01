using Parking_Lot.Constant;
using Parking_Lot.Exceptions;
using Parking_Lot.Model;
using Parking_Lot.Service;
using System.Collections.Generic;

namespace Parking_Lot.Commands
{
    /// <summary>
    /// This class helps in finding the correct command executer based on the command
    /// </summary>
    public class CommandExecutorFactory
    {
        private readonly Dictionary<string, CommandExecutor> commands = new Dictionary<string, CommandExecutor>();

        public CommandExecutorFactory(ParkingLotService parkingLotService)
        {
            commands.Add(CreateParkingLotCommandExecutor.CommandName, new CreateParkingLotCommandExecutor(parkingLotService));
            commands.Add(ParkCommandExecutor.CommandName, new ParkCommandExecutor(parkingLotService));
            commands.Add(LeaveCommandExecutor.CommandName, new LeaveCommandExecutor(parkingLotService));
            commands.Add(StatusCommandExecutor.CommandName, new StatusCommandExecutor(parkingLotService));
            commands.Add(ColorToRegNumberCommandExecutor.CommandName, new ColorToRegNumberCommandExecutor(parkingLotService));
            commands.Add(ColorToSlotNumberCommandExecutor.CommandName, new ColorToSlotNumberCommandExecutor(parkingLotService));
            commands.Add(SlotForRegNumberCommandExecutor.CommandName, new SlotForRegNumberCommandExecutor(parkingLotService));
            commands.Add(ExitCommandExecutor.CommandName, new ExitCommandExecutor(parkingLotService));
        }

        public CommandExecutor GetCommandExecutor(Command command)
        {
            if(!commands.ContainsKey(command.commandName))
            {
                throw new InvalidCommandException(Errors.InvalidCommand);
            }

            return commands[command.commandName];
        }
    }
}
