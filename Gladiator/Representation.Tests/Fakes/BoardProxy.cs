using Gladiator.Representation;
using Gladiator.Utils;
using System;

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
    }
}
