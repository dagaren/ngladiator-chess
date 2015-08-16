using Gladiator.Utils;
using System;

namespace Gladiator.Representation
{
    public static class PositionExtensions
    {
        public static Position<TBoard> GetCopy<TBoard>(this Position<TBoard> position) 
            where TBoard : IBoard, new()
        {
            TBoard board = new TBoard();
            Position<TBoard> clonedPosition = new Position<TBoard>(board, position.moveGenerator, position.positionValidator);

            clonedPosition.Turn = position.Turn;
            clonedPosition.EnPassantSquare = position.EnPassantSquare;
            clonedPosition.SetCastlingRight(CastlingType.Long, Colour.White, position.GetCastlingRight(CastlingType.Long, Colour.White));
            clonedPosition.SetCastlingRight(CastlingType.Long, Colour.Black, position.GetCastlingRight(CastlingType.Long, Colour.Black));
            clonedPosition.SetCastlingRight(CastlingType.Short, Colour.White, position.GetCastlingRight(CastlingType.Short, Colour.White));
            clonedPosition.SetCastlingRight(CastlingType.Short, Colour.Black, position.GetCastlingRight(CastlingType.Short, Colour.Black));

            foreach(Square square in EnumExtensions.GetValues<Square>())
            {
                if(square == Square.None)
                {
                    continue;
                }

                ColouredPiece piece = position.Board.GetPiece(square);

                if(piece != ColouredPiece.None)
                {
                    board.PutPiece(piece, square);
                }
            }

            return clonedPosition;
        }
    }
}
