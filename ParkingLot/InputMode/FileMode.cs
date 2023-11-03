using Parking_Lot.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parking_Lot.InputMode
{
    public class FileMode : Mode
    {
        public FileMode(CommandExecutorFactory commandExecutorFactory) : base(commandExecutorFactory)
        {

        }

        public override void process()
        {
            Console.WriteLine("this is file mode");
        }
    }
}
