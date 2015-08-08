using System;

namespace Gladiator.Communication.Protocols.XBoard.Output
{
    class ErrorCommand : OutputCommand
    {
        public ErrorCommand(ICommandWriter commandWriter) :
            base(commandWriter)
        {
        }

        public void Execute(string reason, string command)
        {
            this.commandWriter.Write(string.Format("Error ({0}): {1}", reason, command));
        }
    }
}
