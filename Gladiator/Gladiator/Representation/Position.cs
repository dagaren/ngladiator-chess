using Gladiator.Utils;
using System;
using System.Collections.Generic;

namespace Gladiator.Representation
{
    class Position<TBoard> : IPosition<TBoard> where TBoard : IBoard
    {
        public TBoard Board { get; private set; }

        public Colour Turn { get; set; }

        private IMoveGenerator<Position<TBoard>, TBoard> moveGenerator;

        public Position(TBoard board, IMoveGenerator<Position<TBoard>, TBoard> moveGenerator)
        {
            Check.ArgumentNotNull(board, "board");
            Check.ArgumentNotNull(moveGenerator, "moveGenerator");

            this.Board = board;
            this.moveGenerator = moveGenerator;
            this.Turn = Colour.White;
        }

        public void DoMove(Move move)
        {
            this.ValidateMove(move);

            ColouredPiece sourcePiece = this.Board.GetPiece(move.Source);
            ColouredPiece destinationPiece = this.Board.GetPiece(move.Destination);
            this.Board.RemovePiece(move.Source);
            if(destinationPiece != ColouredPiece.None)
            {
                this.Board.RemovePiece(move.Destination);
            }
            if(move.Promotion == Piece.None)
            {
                this.Board.PutPiece(sourcePiece, move.Destination);
            }
            else
            {
                this.Board.PutPiece(move.Promotion.GetColoured(this.Turn), move.Destination);
            }

            this.Turn = this.Turn.GetOpponent();
        }

        private void ValidateMove(Move move)
        {
            IList<Move> validMoves = this.moveGenerator.GetMoves(this);
            if (!validMoves.Contains(move))
            {
                throw new ArgumentException(string.Format("Invalid move in this position: {0}", move.Format()));
            }
        }
    }
}
