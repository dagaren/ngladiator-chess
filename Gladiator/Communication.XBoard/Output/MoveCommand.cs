using Gladiator.Representation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gladiator.Communication.XBoard.Output
{
    public class MoveCommand : OutputCommand
    {
        public MoveCommand(ICommandWriter commandWriter) :
            base(commandWriter)
        {
        }

        public void Execute(Move move)
        {
            this.commandWriter.Write(string.Format("move {0}", move.Format()));
        }
    }
}
