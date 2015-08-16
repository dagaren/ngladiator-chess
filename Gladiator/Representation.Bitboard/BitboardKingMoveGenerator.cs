using System;
using System.Collections.Generic;

namespace Gladiator.Representation.Bitboard
{
    public class BitboardKingMoveGenerator<TPosition> : BitboardMoveGenerator<TPosition> where TPosition : IPosition<BitboardBoard>
    {
        protected override Piece GetPiece()
        {
            return Piece.King;
        }

        protected override ulong GetAttackedFrom(Square source, TPosition position)
        {
            return KingBitboards.AttackBitboards[source.GetValue()];
        }

        protected override void AddAditionalMoves(TPosition position, IList<Move> movesList)
        {
            if (position.GetCastlingRight(CastlingType.Short, position.Turn))
            {
                if(position.Board.occupation.And(KingBitboards.CastlingSquares[CastlingType.Short.Value(), position.Turn.Value()]) == BitboardExtensions.Empty)
                {
                    if(!position.Board.IsAttacked(CastlingType.Short.KingSourceSquare(position.Turn), position.Turn.Opponent()) &&
                       !position.Board.AreAttacked(CastlingType.Short.KingCrossingSquare(position.Turn), position.Turn.Opponent()))
                    {
                        movesList.Add(MoveExtensions.GenerateCastling(CastlingType.Short, position.Turn));
                    }
                }
            }

            if (position.GetCastlingRight(CastlingType.Long, position.Turn))
            {
                if (position.Board.occupation.And(KingBitboards.CastlingSquares[CastlingType.Long.Value(), position.Turn.Value()]) == BitboardExtensions.Empty)
                {
                    if (!position.Board.IsAttacked(CastlingType.Long.KingSourceSquare(position.Turn), position.Turn.Opponent()) &&
                        !position.Board.AreAttacked(CastlingType.Long.KingCrossingSquare(position.Turn), position.Turn.Opponent()))
                    {
                        movesList.Add(MoveExtensions.GenerateCastling(CastlingType.Long, position.Turn));
                    }
                }
            }
        }
    }
}