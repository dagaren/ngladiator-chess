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
            this.PreviousWhiteLongCastling = false;
            this.PreviousWhiteLongCastling = false;
            this.PreviousBlackShortCastling = false;
            this.PreviousBlackLongCastling = false;
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

        public bool PreviousWhiteLongCastling { get; set; }

        public bool PreviousBlackLongCastling { get; set; }

        public bool PreviousWhiteShortCastling { get; set; }

        public bool PreviousBlackShortCastling { get; set; }

        public Square PreviousEnPassantSquare { get; set; }
    }
}
