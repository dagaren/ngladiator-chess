using Gladiator.Utils;
using System;
using System.Collections.Generic;

namespace Gladiator.Representation
{
    public class CompositeMoveGenerator<TPosition, TBoard> : IMoveGenerator<TPosition, TBoard> where TPosition : IPosition<TBoard>
    {
        private IEnumerable<IMoveGenerator<TPosition, TBoard>> moveGenerators;

        public CompositeMoveGenerator(IEnumerable<IMoveGenerator<TPosition, TBoard>> moveGenerators)
        {
            Check.ArgumentNotNull(moveGenerators, "moveGenerators");

            this.moveGenerators = moveGenerators;
        }

        public IList<Move> GetMoves(TPosition position)
        {
            List<Move> moves = new List<Move>();

            foreach(IMoveGenerator<TPosition, TBoard> moveGenerator in this.moveGenerators)
            {
                moves.AddRange(moveGenerator.GetMoves(position));
            }

            return moves;
        }
    }
}
