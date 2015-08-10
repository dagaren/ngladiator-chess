using System;

namespace Gladiator.Representation
{
    public static class CastlingTypeExtensions
    {
        private static Square[,] RookSourceSquares = new Square[2, 2];

        private static Square[,] RookDestinationSquares = new Square[2, 2];

        private static Square[,] KingSourceSquares = new Square[2, 2];

        private static Square[,] KingDestinationSquares = new Square[2, 2];

        static CastlingTypeExtensions()
        {
            RookSourceSquares[CastlingType.Long.Value(), Colour.White.Value()] = Square.a1;
            RookSourceSquares[CastlingType.Short.Value(), Colour.White.Value()] = Square.h1;
            RookSourceSquares[CastlingType.Long.Value(), Colour.Black.Value()] = Square.a8;
            RookSourceSquares[CastlingType.Short.Value(), Colour.Black.Value()] = Square.h8;

            RookDestinationSquares[CastlingType.Long.Value(), Colour.White.Value()] = Square.d1;
            RookDestinationSquares[CastlingType.Short.Value(), Colour.White.Value()] = Square.f1;
            RookDestinationSquares[CastlingType.Long.Value(), Colour.Black.Value()] = Square.d8;
            RookDestinationSquares[CastlingType.Short.Value(), Colour.Black.Value()] = Square.f8;

            KingSourceSquares[CastlingType.Long.Value(), Colour.White.Value()] = Square.e1;
            KingSourceSquares[CastlingType.Short.Value(), Colour.White.Value()] = Square.e1;
            KingSourceSquares[CastlingType.Long.Value(), Colour.Black.Value()] = Square.e8;
            KingSourceSquares[CastlingType.Short.Value(), Colour.Black.Value()] = Square.e8;

            KingDestinationSquares[CastlingType.Long.Value(), Colour.White.Value()] = Square.c1;
            KingDestinationSquares[CastlingType.Short.Value(), Colour.White.Value()] = Square.g1;
            KingDestinationSquares[CastlingType.Long.Value(), Colour.Black.Value()] = Square.c8;
            KingDestinationSquares[CastlingType.Short.Value(), Colour.Black.Value()] = Square.g8;
        }

        public static int Value(this CastlingType type)
        {
            return (int)type;
        }

        public static Square RookSourceSquare(this CastlingType type, Colour colour)
        {
            if(colour == Colour.None)
            {
                return Square.None;
            }

            return RookSourceSquares[type.Value(), colour.Value()];
        }

        public static Square RookDestinationSquare(this CastlingType type, Colour colour)
        {
            if (colour == Colour.None)
            {
                return Square.None;
            }

            return RookDestinationSquares[type.Value(), colour.Value()];
        }

        public static Square KingSourceSquare(this CastlingType type, Colour colour)
        {
            if (colour == Colour.None)
            {
                return Square.None;
            }

            return KingSourceSquares[type.Value(), colour.Value()];
        }

        public static Square KingDestinationSquare(this CastlingType type, Colour colour)
        {
            if (colour == Colour.None)
            {
                return Square.None;
            }

            return KingDestinationSquares[type.Value(), colour.Value()];
        }
    }
}
