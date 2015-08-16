using System;

namespace Gladiator.Representation
{
    public class InitialChessPositionBuilder<TBoard> : PositionBuilder<TBoard> 
        where TBoard  : IBoard, new()
    {
        public InitialChessPositionBuilder(
                               IMoveGenerator<Position<TBoard>, TBoard> moveGenerator,
                               IPositionValidator<Position<TBoard>, TBoard> positionValidator) : base(moveGenerator, positionValidator)
        {
            this.PutPiece(ColouredPiece.WhiteKing, Square.e1)
                .PutPiece(ColouredPiece.BlackKing, Square.e8)
                .PutPiece(ColouredPiece.WhiteKnight, Square.b1)
                .PutPiece(ColouredPiece.WhiteKnight, Square.g1)
                .PutPiece(ColouredPiece.BlackKnight, Square.b8)
                .PutPiece(ColouredPiece.BlackKnight, Square.g8)
                .PutPiece(ColouredPiece.WhiteRook, Square.a1)
                .PutPiece(ColouredPiece.WhiteRook, Square.h1)
                .PutPiece(ColouredPiece.BlackRook, Square.a8)
                .PutPiece(ColouredPiece.BlackRook, Square.h8)
                .PutPiece(ColouredPiece.WhiteBishop, Square.c1)
                .PutPiece(ColouredPiece.WhiteBishop, Square.f1)
                .PutPiece(ColouredPiece.BlackBishop, Square.c8)
                .PutPiece(ColouredPiece.BlackBishop, Square.f8)
                .PutPiece(ColouredPiece.WhiteQueen, Square.d1)
                .PutPiece(ColouredPiece.BlackQueen, Square.d8)
                .PutPiece(ColouredPiece.WhitePawn, Square.a2)
                .PutPiece(ColouredPiece.WhitePawn, Square.b2)
                .PutPiece(ColouredPiece.WhitePawn, Square.c2)
                .PutPiece(ColouredPiece.WhitePawn, Square.d2)
                .PutPiece(ColouredPiece.WhitePawn, Square.e2)
                .PutPiece(ColouredPiece.WhitePawn, Square.f2)
                .PutPiece(ColouredPiece.WhitePawn, Square.g2)
                .PutPiece(ColouredPiece.WhitePawn, Square.h2)
                .PutPiece(ColouredPiece.BlackPawn, Square.a7)
                .PutPiece(ColouredPiece.BlackPawn, Square.b7)
                .PutPiece(ColouredPiece.BlackPawn, Square.c7)
                .PutPiece(ColouredPiece.BlackPawn, Square.d7)
                .PutPiece(ColouredPiece.BlackPawn, Square.e7)
                .PutPiece(ColouredPiece.BlackPawn, Square.f7)
                .PutPiece(ColouredPiece.BlackPawn, Square.g7)
                .PutPiece(ColouredPiece.BlackPawn, Square.h7)
                .SetCastlingRight(CastlingType.Long, Colour.White, true)
                .SetCastlingRight(CastlingType.Long, Colour.Black, true)
                .SetCastlingRight(CastlingType.Short, Colour.White, true)
                .SetCastlingRight(CastlingType.Short, Colour.Black, true)
                .SetEnPassantSquare(Square.None);
        }
    }
}
