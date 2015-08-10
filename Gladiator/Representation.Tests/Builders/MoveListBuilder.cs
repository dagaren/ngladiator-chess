using Gladiator.Representation;
using System;
using System.Collections.Generic;

namespace Gladiator.Representation.Tests.Builders
{
    public class MoveListBuilder
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

        public MoveListBuilder AddMove(Move move)
        {
            this.moveList.Add(move);

            return this;
        }

        public MoveListBuilder AddMoves(IEnumerable<Move> moves)
        {
            this.moveList.AddRange(moves);

            return this;
        }

        public MoveListBuilder AddMoves(Square source, IEnumerable<Square> destinations)
        {
            foreach(Square destination in destinations)
            {
                AddMove(source, destination);
            }

            return this;
        }

        public List<Move> Build()
        {
            return moveList;
        }

        public static implicit operator List<Move>(MoveListBuilder instance)
        {
            return instance.Build();
        }
    }
}
