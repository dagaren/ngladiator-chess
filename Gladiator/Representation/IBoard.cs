using System;
using System.Collections.Generic;

namespace Gladiator.Representation
{
    public interface IBoard
    {
        void PutPiece(ColouredPiece piece, Square square);

        void RemovePiece(Square square);

        ColouredPiece GetPiece(Square square);

        bool IsAttacked(Square square, Colour turn);

        IEnumerable<Square> GetSquaresWithPiece(ColouredPiece piece);

        int GetNumPieces(ColouredPiece piece);
    }
}
