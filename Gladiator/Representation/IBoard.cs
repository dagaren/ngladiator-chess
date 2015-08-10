using System;

namespace Gladiator.Representation
{
    public interface IBoard
    {
        void PutPiece(ColouredPiece piece, Square square);

        void RemovePiece(Square square);

        ColouredPiece GetPiece(Square square);
    }
}
