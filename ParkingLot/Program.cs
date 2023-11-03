using Parking_Lot.Commands;
using Parking_Lot.Constant;
using Parking_Lot.Exceptions;
using Parking_Lot.InputMode;
using Parking_Lot.Service;
using System;

namespace Parking_Lot
{
    public static class Program
    {
        static void Main(string[] args)
        {
            try
            {
                ParkingLotService parkingLotService = new ParkingLotService();

                CommandExecutorFactory commandExecutorFactory = new CommandExecutorFactory(parkingLotService);

                if (IsInterativeInputMode(args))
                {
                    new InteractiveMode(commandExecutorFactory).process();
                }
                else if (IsFileInputMode(args))
                {
                    new FileMode(commandExecutorFactory).process();
                }
                else
                {
                    throw new InvalidModeException(Errors.InvalidInputMode);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                Console.ReadLine();
            }
        }

        private static bool IsFileInputMode(string[] args)
        {
            return args.Length == 1;
        }

        private static bool IsInterativeInputMode(string[] args)
        {
            return args.Length == 0;
        }
    }
}
