using Gladiator.Representation;
using Gladiator.Utils;
using System;
using System.Collections.Generic;

namespace Gladiator.Representation.Tests.Fakes
{
    public class BoardProxy : IBoard
    {
        private IBoard targetBoard;

        public BoardProxy(IBoard targetBoard)
        {
            Check.ArgumentNotNull(targetBoard, "targetBoard");

            this.targetBoard = targetBoard;
        }

        public void PutPiece(ColouredPiece piece, Square square)
        {
            this.targetBoard.PutPiece(piece, square);
        }

        public void RemovePiece(Square square)
        {
            this.targetBoard.RemovePiece(square);
        }

        public ColouredPiece GetPiece(Square square)
        {
            return this.targetBoard.GetPiece(square);
        }

        public bool IsAttacked(Square square, Colour turn)
        {
            return this.targetBoard.IsAttacked(square, turn);
        }

        public IEnumerable<Square> GetSquaresWithPiece(ColouredPiece piece)
        {
            return this.targetBoard.GetSquaresWithPiece(piece);
        }

        public int GetNumPieces(ColouredPiece piece)
        {
            return this.targetBoard.GetNumPieces(piece);
        }
    }
}
