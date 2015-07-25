using Gladiator.Representation;
using System;
using System.Collections.Generic;

namespace Gladiator.Tests.Representation.Builders
{
    class MoveListBuilder
    {
        private List<Move> moveList = new List<Move>();

        public MoveListBuilder AddMove(Square source, Square destination)
        {
            return this.AddMove(source, destination, Piece.None);
        }

        public MoveListBuilder AddMove(Square source, Square destination, Piece promotion)
        {
            this.moveList.Add(new Move(source, destination, promotion));

            return this;
        }

        public List<Move> Build()
        {
            return moveList;
        }
    }
}
