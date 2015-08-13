using Gladiator.Representation;
using Gladiator.Representation.Notation;
using Gladiator.Utils;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Gladiator.Communication.XBoard
{
    public class MoveCommand : ICommand 
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
            IEnumerable<Move> legalMoves = this.position.GetMoves(MoveSearchType.LegalMoves);

            if(legalMoves.Contains(this.move))
            {
                this.position.DoMove(this.move);

                //Console.WriteLine("Making move " + move.Format());
                //ConsoleExtensions.WriteLineColoured("Position turn: " + this.position.Turn.ToString(), ConsoleColor.Green);
                //ConsoleExtensions.WriteLineColoured("En passant square " + this.position.EnPassantSquare, ConsoleColor.Yellow);
                //this.position.Board.WriteConsolePretty();
            }
            else
            {
                this.illegalMoveAction(this.move, string.Empty);
            }
        }
    }
}
