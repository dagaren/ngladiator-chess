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

        private Action<Move, string> illegalMoveAction;

        public MoveCommand(
            IPosition<IBoard> position,
            [CommmandParameter(typeof(AlgebraicCoordinateParser))]Move move,
            Action<Move, string> illegalMoveAction
            )
        {
            Check.ArgumentNotNull(position, "position");
            Check.ArgumentNotNull(move, "move");
            Check.ArgumentNotNull(illegalMoveAction, "illegalMoveAction");

            this.position = position;
            this.move = move;
            this.illegalMoveAction = illegalMoveAction;
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
                this.illegalMoveAction(this.move, string.Empty);
            }
        }
    }
}
