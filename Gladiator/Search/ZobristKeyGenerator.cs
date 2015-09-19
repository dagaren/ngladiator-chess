using System;
using Gladiator.Utils;
using Gladiator.Representation;

namespace Gladiator.Search
{
    class ZobristKeyGenerator
    {
        private static readonly ulong[,] pieceRandoms = new ulong[12, 64];
        
        private static readonly ulong[,] castlingRandoms = new ulong[2, 2];

        private static readonly ulong turnRandom;

        private static readonly ulong[] enPassantSquareRandoms = new ulong[8];

        static ZobristKeyGenerator()
        {
            Random random = new Random();
            
            for(int i = 0; i < pieceRandoms.GetLength(0); i++)
            {
                for (int j = 0; j < pieceRandoms.GetLength(1); j++)
                {
                    pieceRandoms[i, j] = random.NextULong();
                }
            }

            for(int i = 0; i < castlingRandoms.GetLength(0); i++)
            {
                for (int j = 0; j < castlingRandoms.GetLength(1); j++)
                {
                    castlingRandoms[i, j] = random.NextULong();
                }
            }

            turnRandom = random.NextULong();

            for(int i = 0; i < 8; i++)
            {
                enPassantSquareRandoms[i] = random.NextULong();
            }
        }

        public ulong GenerateZobrist(IPosition<IBoard> position)
        {
            ulong zobrist = 0;

            foreach(ColouredPiece piece in ColouredPieceExtensions.AllPieces())
            {
                foreach(Square square in position.Board.GetSquaresWithPiece(piece))
                {
                    zobrist ^= pieceRandoms[piece.GetValue(), square.GetValue()]; 
                }
            }

            if(position.Turn == Colour.Black)
            {
                zobrist ^= turnRandom;
            }

            if(position.EnPassantSquare != Square.None)
            {
                zobrist ^= enPassantSquareRandoms[position.EnPassantSquare.GetFile().GetValue()];
            }

            foreach(CastlingType castlingType in CastlingTypeExtensions.AllTypes())
            {
                foreach(Colour colour in ColourExtensions.AllColours())
                {
                    if(position.GetCastlingRight(castlingType, colour))
                    {
                        zobrist ^= castlingRandoms[castlingType.Value(), colour.Value()];
                    }
                }
            }

            return zobrist;
        }
    }
}
