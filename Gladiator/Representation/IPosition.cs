using System;
using System.Collections.Generic;

namespace Gladiator.Representation
{
    public interface IPosition<out IBoard>
    {
        IBoard Board { get; }

        Colour Turn { get; set; }

        Square EnPassantSquare { get; set; }

        void SetCastlingRight(CastlingType type, Colour color, bool enabled);

        bool GetCastlingRight(CastlingType type, Colour color);

        FullMove DoMove(Move move);

        void UndoMove(FullMove move);

        IEnumerable<Move> GetMoves(MoveSearchType searchType);
    }
}
