using System;
using System.Collections.Generic;

namespace Gladiator.Representation
{
    public static class CastlingTypeExtensions
    {
        private static readonly Square[,] RookSourceSquares = new Square[2, 2];
        private static readonly Square[,] RookDestinationSquares = new Square[2, 2];
        private static readonly Square[,] KingSourceSquares = new Square[2, 2];
        private static readonly Square[,] KingDestinationSquares = new Square[2, 2];
        private static readonly IEnumerable<Square>[,] KingCrossingSquares = new IEnumerable<Square>[2, 2];
        private static readonly IEnumerable<CastlingType> allCastlingTypes = new CastlingType[] { CastlingType.Long, CastlingType.Short };

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

            KingCrossingSquares[CastlingType.Long.Value(), Colour.White.Value()] =  new Square[] { Square.d1, Square.c1 };
            KingCrossingSquares[CastlingType.Short.Value(), Colour.White.Value()] = new Square[] { Square.f1, Square.g1 };
            KingCrossingSquares[CastlingType.Long.Value(), Colour.Black.Value()] = new Square[] { Square.d8, Square.c8 };
            KingCrossingSquares[CastlingType.Short.Value(), Colour.Black.Value()] = new Square[] { Square.f8, Square.g8 };
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

        public static IEnumerable<Square> KingCrossingSquare(this CastlingType type, Colour colour)
        {
            if (colour == Colour.None)
            {
                return new Square[0];
            }

            return KingCrossingSquares[type.Value(), colour.Value()];
        }

        public static IEnumerable<CastlingType> AllTypes()
        {
            return allCastlingTypes;
        }
    }
}
