using System;
using System.Collections.Generic;

namespace Gladiator.Representation.Bitboard
{
    class BitboardPawnMoveGenerator<TPosition> : BitboardMoveGenerator<TPosition> where TPosition : IPosition<BitboardBoard>
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
                attackedBitboard |= PawnBitboards.WhiteAttackBitboards[source.GetValue()].And(position.Board.colourOccupation[piece.GetColour().GetOpponent().GetValue()]);
                attackedBitboard |= PawnBitboards.WhiteReachBitboards[source.GetValue()].And(position.Board.occupation.Inverse());
                attackedBitboard = attackedBitboard.Unset(position.Board.occupation
                                                      .Unset(position.Board.pieceOccupation[piece.GetColour().GetValue()])
                                                      .ShiftRight(8).And(Rank._4.GetBitboard())); 
            }
            else if(piece == ColouredPiece.BlackPawn)
            {
                attackedBitboard |= PawnBitboards.BlackAttackBitboards[source.GetValue()].And(position.Board.colourOccupation[piece.GetColour().GetOpponent().GetValue()]);
                attackedBitboard |= PawnBitboards.BlackReachBitboards[source.GetValue()].And(position.Board.occupation.Inverse());
                attackedBitboard = attackedBitboard.Unset(position.Board.occupation
                                                      .Unset(position.Board.pieceOccupation[piece.GetColour().GetValue()])
                                                      .ShiftLeft(8).And(Rank._5.GetBitboard())); 
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
