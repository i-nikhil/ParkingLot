using Parking_Lot.Commands;
using Parking_Lot.Constant;
using Parking_Lot.Exceptions;
using Parking_Lot.Model;

namespace Parking_Lot.InputMode
{
    public abstract class Mode
    {
        private CommandExecutorFactory commandExecutorFactory;

        protected Mode (CommandExecutorFactory commandExecutorFactory)
        {
            this.commandExecutorFactory = commandExecutorFactory;
        }

        // Helper method to process a command
        protected void ProcessCommand(Command command)
        {
            CommandExecutor executor = commandExecutorFactory.GetCommandExecutor(command);
            executor.Execute(command);
        }

        // Abstract method to process the mode
        public abstract void process();
    }
}
