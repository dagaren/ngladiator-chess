﻿using System;
using System.Collections.Generic;

namespace Gladiator.Representation.Bitboard
{
    public class BitboardPawnMoveGenerator<TPosition> : BitboardMoveGenerator<TPosition> where TPosition : IPosition<BitboardBoard>
    {
        protected override Piece GetPiece()
        {
            return Piece.Pawn;
        }

        protected override ulong GetAttackedFrom(Square source, TPosition position)
        {
            ColouredPiece piece = position.Board.piecesInSquare[source.GetValue()];
            ulong attackedBitboard = BitboardExtensions.Empty;

            if(piece == ColouredPiece.WhitePawn)
            {
                attackedBitboard |= PawnBitboards.ReachBitboards[Colour.White.Value(), source.GetValue()].And(position.Board.occupation.Inverse());
                if(source.GetRank() == Rank._2)
                {
                    attackedBitboard |= attackedBitboard.And(position.Board.occupation.Inverse()).ShiftRight(8).And(position.Board.occupation.Inverse());
                }
                attackedBitboard |= PawnBitboards.AttackBitboards[Colour.White.Value(), source.GetValue()].And(position.Board.colourOccupation[piece.GetColour().Opponent().Value()]);

                if(source == position.EnPassantSquare.PreviousInDiagonal() || source == position.EnPassantSquare.PreviousInAntiDiagonal())
                {
                    attackedBitboard |= position.EnPassantSquare.GetBitboard();
                }
            }
            else if(piece == ColouredPiece.BlackPawn)
            {
                attackedBitboard |= PawnBitboards.ReachBitboards[Colour.Black.Value(), source.GetValue()].And(position.Board.occupation.Inverse());
                if(source.GetRank() == Rank._7)
                {
                    attackedBitboard |= attackedBitboard.And(position.Board.occupation.Inverse()).ShiftLeft(8).And(position.Board.occupation.Inverse());
                }
                attackedBitboard |= PawnBitboards.AttackBitboards[Colour.Black.Value(), source.GetValue()].And(position.Board.colourOccupation[piece.GetColour().Opponent().Value()]);

                if (source == position.EnPassantSquare.NextInDiagonal() || source == position.EnPassantSquare.NextInAntiDiagonal())
                {
                    attackedBitboard |= position.EnPassantSquare.GetBitboard();
                }
            }
            
            return attackedBitboard;
        }

        protected override void AddMove(Square source, Square destination, IList<Move> movesList)
        {
            if(destination.GetRank() == Rank._1 || destination.GetRank() == Rank._8)
            {
                movesList.Add(new Move { Source = source, Destination = destination, Promotion = Piece.Queen });
                movesList.Add(new Move { Source = source, Destination = destination, Promotion = Piece.Rook });
                movesList.Add(new Move { Source = source, Destination = destination, Promotion = Piece.Bishop });
                movesList.Add(new Move { Source = source, Destination = destination, Promotion = Piece.Knight });
            }
            else
            {
                base.AddMove(source, destination, movesList);
            }
        }
    }
}
