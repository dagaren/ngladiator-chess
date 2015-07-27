using Gladiator.Representation;
using Gladiator.Representation.Notation;
using Gladiator.Utils;
using System;

namespace Gladiator.Communication.Protocols.XBoard
{
    class MoveCommand : ICommand 
    {
        private IPosition<IBoard> position;

        private Move move;

        private ICommandWriter commandWriter;

        public MoveCommand(
            IPosition<IBoard> position,
            [CommmandParameter(typeof(AlgebraicCoordinateParser))]Move move,
            ICommandWriter commandWriter)
        {
            Check.ArgumentNotNull(position, "position");
            Check.ArgumentNotNull(move, "move");
            Check.ArgumentNotNull(commandWriter, "commandWriter");

            this.position = position;
            this.move = move;
            this.commandWriter = commandWriter;
        }

        public void Execute()
        {
            try
            {
                this.position.DoMove(this.move);

                Console.WriteLine("Making move " + move.Format());
                ConsoleExtensions.WriteLineColoured("Position turn: " + this.position.Turn.ToString(), ConsoleColor.Green);
                this.position.Board.WriteConsolePretty();
            }
            catch(Exception)
            {
                this.commandWriter.Write(string.Format("Invalid move: {0}", this.move.Format()));
            }
        }
    }
}
