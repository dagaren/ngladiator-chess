using System;

namespace Gladiator.Representation
{
    public static class MoveExtensions
    {
        public static string Format(this Move move)
        {
            return string.Format("{0}{1}", move.Source, move.Destination);
        }

        public static CastlingType Castling(this Move move, ColouredPiece sourcePiece)
        {
            if(sourcePiece.GetPiece() == Piece.King)
            {
                if(move.Source == CastlingType.Long.KingSourceSquare(sourcePiece.GetColour()) &&
                   move.Destination == CastlingType.Long.KingDestinationSquare(sourcePiece.GetColour()))
                {
                    return CastlingType.Long;
                }
                else if(move.Source == CastlingType.Short.KingSourceSquare(sourcePiece.GetColour()) &&
                   move.Destination == CastlingType.Short.KingDestinationSquare(sourcePiece.GetColour()))
                {
                    return CastlingType.Short;
                }
            }
           
            return CastlingType.None;
        }

        public static Square EnPassantSquareGenerated(this Move move, ColouredPiece sourcePiece)
        {
            if(sourcePiece.GetPiece() == Piece.Pawn &&
                PawnExtensions.EnPassantSourceRanks[sourcePiece.GetColour().Value()] == move.Source.GetRank() &&
                PawnExtensions.EnPassantDestinationRanks[sourcePiece.GetColour().Value()] == move.Destination.GetRank())
            {
                if(sourcePiece.GetColour() == Colour.White)
                {
                    return move.Destination.PreviousInFile();
                }
                else
                {
                    return move.Destination.NextInFile();
                }
            }

            return Square.None;
        }

        public static Move GenerateCastling(CastlingType type, Colour colour)
        {
            return new Move()
            {
                Source = type.KingSourceSquare(colour),
                Destination = type.KingDestinationSquare(colour)
            };
        }
    }
}
