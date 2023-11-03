using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parking_Lot.Model
{
    public class Command
    {
        public string commandName { get; private set; }
        public string[] parameters { get; private set; }

        public Command(string input)
        {
            string[] splittedCommand = input.Split(' ');
            commandName = splittedCommand.FirstOrDefault();

            parameters = new string[splittedCommand.Length - 1];
            Array.Copy(splittedCommand, 1, parameters, 0, splittedCommand.Length - 1);
        }
    }
}
