using Gladiator.Representation;
using Gladiator.Utils;
using System;

namespace Gladiator.Tests.Representation.Fakes
{
    public class SimpleBoard : IBoard
    {
        private readonly ColouredPiece[] pieces = new ColouredPiece[64];

        public SimpleBoard()
        {
            foreach(Square square in EnumExtensions.GetValues<Square>())
            {
                if(square == Square.None)
                {
                    continue;
                }

                this.pieces[square.GetValue()] = ColouredPiece.None;
            }
        }

        public void PutPiece(ColouredPiece piece, Square square)
        {
            this.pieces[square.GetValue()] = piece;
        }

        public void RemovePiece(Square square)
        {
            this.pieces[square.GetValue()] = ColouredPiece.None;
        }

        public ColouredPiece GetPiece(Square square)
        {
            return this.pieces[square.GetValue()];
        }
    }
}
