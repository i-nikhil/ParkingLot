using Parking_Lot.Commands;
using Parking_Lot.Constant;
using Parking_Lot.Model;
using System;

namespace Parking_Lot.InputMode
{
    public class InteractiveMode : Mode
    {
        public InteractiveMode(CommandExecutorFactory commandExecutorFactory) : base(commandExecutorFactory)
        {
        }

        public override void process()
        {
            Console.WriteLine(Messages.Welcome);

            while (true)
            {
                try
                {
                    string input = Console.ReadLine();

                    Command command = new Command(input);

                    ProcessCommand(command);

                    if (command.commandName == ExitCommandExecutor.CommandName)
                    {
                        break;
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
        }
    }
}