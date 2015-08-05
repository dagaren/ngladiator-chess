using Gladiator.Representation;
using System;

namespace Gladiator.Communication.Protocols.XBoard.Output
{
    class IllegalMoveCommand : OutputCommand
    {
        private const string FormatString = "Illegal move: {0}";

        private const string FormatStringWithReason = "Illegal move ({1}): {0}";

        public IllegalMoveCommand(ICommandWriter commandWriter) :
            base(commandWriter)
        {
        }

        public void Execute(Move move, string reason)
        {
            string formatString = string.IsNullOrWhiteSpace(reason) ? FormatString : FormatStringWithReason;

            this.commandWriter.Write(string.Format(formatString, move.Format(), reason));
        }
    }
}
