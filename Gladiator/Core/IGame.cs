using Gladiator.Representation;
using System;
using System.Collections.Generic;

namespace Gladiator.Core
{
    public interface IGame
    {
        Colour Turn { get; }

        IPosition<IBoard> Position { get; }

        void DoMove(Move move);

        IEnumerable<Move> GetMoves();


    }
}
