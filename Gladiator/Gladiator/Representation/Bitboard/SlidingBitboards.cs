﻿using Gladiator.Utils;
using System;
using System.Threading;

namespace Gladiator.Representation.Bitboard
{
    class SlidingBitboards
    {
        private static readonly ulong[,] RankAttack = new ulong[64, 256];

        private static readonly ulong[,] FileAttack = new ulong[64, 256];

        static SlidingBitboards()
        {
            foreach(Square square in EnumExtensions.GetValues<Square>())
            {
                if(square == Square.None)
                {
                    continue;
                }

                Rank rank = square.GetRank();
                ulong bitboardSquare = square.GetBitboard();

                for(uint occupation = 0; occupation < 256; occupation++)
                {
                    ulong bitboard = rank.OccupationBitboard((byte)occupation);
                    
                    if(bitboardSquare.And(bitboard) != BitboardExtensions.Empty)
                    {
                        // Attacking squares on the right
                        ulong attackingSquaresBitboard = square.RightBitboard();

                        ulong blockingSquaresBitboard = attackingSquaresBitboard.And(bitboard);

                        if(blockingSquaresBitboard != BitboardExtensions.Empty)
                        {
                            attackingSquaresBitboard ^= blockingSquaresBitboard.FirstSquareScan().RightBitboard();
                        }

                        RankAttack[square.GetValue(), occupation] = attackingSquaresBitboard;

                        // Attacking squares on the left
                        attackingSquaresBitboard = square.LeftBitboard();

                        blockingSquaresBitboard = attackingSquaresBitboard.And(bitboard);

                        if(blockingSquaresBitboard != BitboardExtensions.Empty)
                        {
                            attackingSquaresBitboard ^= blockingSquaresBitboard.LastSquareScan().LeftBitboard(); 
                        }

                        RankAttack[square.GetValue(), occupation] ^= attackingSquaresBitboard;
                    }
                    else
                    {
                        RankAttack[square.GetValue(), occupation] = BitboardExtensions.Empty;
                    }

                    // The attack in files is calculated based on the rank attack (by rotating)
                    FileAttack[square.Rotated90DegreesRight().GetValue(), occupation] = RankAttack[square.GetValue(), occupation].Rotate90DegreesRight();
                }
            }
        }

        public static ulong GetRankAttack(Square square, ulong bitboard)
        {
            byte occupation = bitboard.RankOccupation(square.GetRank());

            return RankAttack[square.GetValue(), occupation];
        }

        public static ulong GetFileAttack(Square square, ulong bitboard)
        {
            byte occupation = bitboard.Rotate90DegreesLeft().RankOccupation(square.Rotated90DegreesLeft().GetRank());

            return FileAttack[square.GetValue(), occupation];
        }
    }
}
