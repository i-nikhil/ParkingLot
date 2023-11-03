using Parking_Lot.Commands;
using Parking_Lot.Constant;
using Parking_Lot.Exceptions;
using Parking_Lot.Model;

namespace Parking_Lot.InputMode
{
    public abstract class Mode
    {
        private readonly CommandExecutorFactory commandExecutorFactory;

        protected Mode(CommandExecutorFactory commandExecutorFactory)
        {
            this.commandExecutorFactory = commandExecutorFactory;
        }

        // Common helper method to process a command
        protected void ProcessCommand(Command command)
        {
            CommandExecutor executor = commandExecutorFactory.GetCommandExecutor(command);
            if (executor.Validate(command))
            {
                executor.Execute(command);
            }
            else
            {
                throw new InvalidCommandException(Errors.InvalidCommand);
            }
        }

        // Abstract method to process the mode
        public abstract void process();
    }
}