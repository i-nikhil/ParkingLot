using Parking_Lot.Commands;
using Parking_Lot.Constant;
using Parking_Lot.Model;
using System;
using System.IO;

namespace Parking_Lot.InputMode
{
    public class FileMode : Mode
    {
        private readonly string filePath;

        public FileMode(CommandExecutorFactory commandExecutorFactory, string filePath) : base(commandExecutorFactory)
        {
            this.filePath = filePath;
        }

        public override void process()
        {
            Console.WriteLine(Messages.WelcomeToFileMode);

            StreamReader sr = new StreamReader(filePath);

            string[] lines = sr.ReadToEnd().Split(new string[] { Environment.NewLine }, StringSplitOptions.None);

            foreach (string line in lines)
            {
                try
                {
                    Command command = new Command(line);

                    ProcessCommand(command);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }

            sr.Close();
        }
    }
}