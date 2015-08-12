using System;

namespace Gladiator.Representation
{
    public class FullMove : Move
    {
        public FullMove()
        {
            this.SourcePiece = ColouredPiece.None;
            this.DestinationPiece = ColouredPiece.None;
            this.IsInPassantCapture = false;
            this.CancelsLongCastling = false;
            this.CancelsShortCastling = false;
            this.PreviousEnPassantSquare = Square.None;
        }

        public FullMove(Move move)
        {
            this.Source = move.Source;
            this.Destination = move.Destination;
            this.Promotion = move.Promotion;
        }

        public ColouredPiece SourcePiece { get; set; }

        public ColouredPiece DestinationPiece { get; set; }

        public bool IsInPassantCapture { get; set; }

        public bool CancelsLongCastling { get; set; }

        public bool CancelsShortCastling { get; set; }

        public Square PreviousEnPassantSquare { get; set; }
    }
}
