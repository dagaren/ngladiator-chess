using System;
using System.Collections.Generic;

namespace Gladiator.Representation.Bitboard
{
    class BitboardKingMoveGenerator<TPosition> : IMoveGenerator<TPosition, BitboardBoard> where TPosition : IPosition<BitboardBoard>
    {
        public IList<Move> GetMoves(TPosition position)
        {
            IList<Move> movesList = new List<Move>();

            ColouredPiece colouredPiece = Piece.King.GetColoured(position.Turn);

            ulong pieceBitboard = position.Board.pieceOccupation[colouredPiece.GetValue()];

            while(pieceBitboard != BitboardExtensions.Empty)
            {
                Square source = pieceBitboard.FirstSquareScan();

                ulong attackedBitboard = KingBitboards.AttackBitboards[source.GetValue()];

                attackedBitboard = attackedBitboard.Unset(position.Board.colourOccupation[position.Turn.GetValue()]);

                while(attackedBitboard != BitboardExtensions.Empty)
                {
                    Square destination = attackedBitboard.FirstSquareScan();

                    Move move = new Move()
                    {
                        Source = source,
                        Destination = destination
                    };

                    movesList.Add(move);

                    attackedBitboard = attackedBitboard.Xor(destination.GetBitboard());
                }

                pieceBitboard = pieceBitboard.Xor(source.GetBitboard());
            }

            return movesList;
        }
    }
}
