namespace Gladiator.Representation
{
    using System.Collections.Generic;

    public interface IBoard
    {
        void PutPiece(ColouredPiece piece, Square square);

        void RemovePiece(Square square);

        ColouredPiece GetPiece(Square square);

        IEnumerable<Square> GetSquaresWithPiece(ColouredPiece piece);

        int GetNumPieces(ColouredPiece piece);
    }
}
