using Gladiator.Representation;
using Gladiator.Utils;
using System;
using System.Linq;
using System.Collections.Generic;

namespace Gladiator.Core
{
    public class Game : IGame
    {
        public Colour Turn { get { return this.position.Turn; } }

        public IPosition<IBoard> Position { get { return this.position; } }

        private IPosition<IBoard> position;

        public Game(IPosition<IBoard> initialPosition)
        {
            Check.ArgumentNotNull(initialPosition, "initialPosition");

            this.position = initialPosition;
        }

        public void DoMove(Move move)
        {
            IEnumerable<Move> legalMoves = this.position.GetMoves(MoveSearchType.LegalMoves);

            if (legalMoves.Contains(move))
            {
                this.position.DoMove(move);
            }
            else
            {
                throw new IllegalMoveException();
            }
        }

        public IEnumerable<Move> GetMoves()
        {
            return this.position.GetMoves(MoveSearchType.LegalMoves);
        }
    }
}
