﻿using System;
using System.Collections.Generic;

namespace Gladiator.Representation.Bitboard
{
    public abstract class BitboardMoveGenerator<TPosition> : IMoveGenerator<TPosition, BitboardBoard> where TPosition : IPosition<BitboardBoard>
    {
        public IList<Move> GetMoves(TPosition position)
        {
            IList<Move> movesList = new List<Move>();

            ColouredPiece colouredPiece = GetPiece().GetColoured(position.Turn);

            ulong pieceBitboard = position.Board.pieceOccupation[colouredPiece.GetValue()];

            while (pieceBitboard != BitboardExtensions.Empty)
            {
                Square source = pieceBitboard.FirstSquareScan();

                ulong attackedBitboard = GetAttackedFrom(source, position);

                attackedBitboard = attackedBitboard.Unset(position.Board.colourOccupation[position.Turn.Value()]);

                while (attackedBitboard != BitboardExtensions.Empty)
                {
                    Square destination = attackedBitboard.FirstSquareScan();

                    this.AddMove(source, destination, movesList);
                    
                    attackedBitboard = attackedBitboard.Xor(destination.GetBitboard());
                }

                pieceBitboard = pieceBitboard.Xor(source.GetBitboard());
            }

            AddAditionalMoves(position, movesList);

            return movesList;
        }

        protected abstract Piece GetPiece();

        protected abstract ulong GetAttackedFrom(Square square, TPosition position);

        protected virtual void AddMove(Square source, Square destination, IList<Move> movesList)
        {
            Move move = new Move()
                        {
                            Source = source,
                            Destination = destination
                        };
            movesList.Add(move);
        }

        protected virtual void AddAditionalMoves(TPosition position, IList<Move> movesList)
        {
            return;
        }
    }
}
