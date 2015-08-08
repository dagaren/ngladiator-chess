using Gladiator.Utils;
using System;
using System.Threading;

namespace Gladiator.Representation.Bitboard
{
    public class SlidingBitboards
    {
        private static readonly ulong[,] RankAttack = new ulong[64, 256];

        private static readonly ulong[,] FileAttack = new ulong[64, 256];

        private static readonly ulong[,] DiagonalAttack = new ulong[64, 256];

        private static readonly ulong[,] AntidiagonalAttack = new ulong[64, 256];

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

                    // The attack in files is calculated based on the rank attack (by rotation)
                    FileAttack[square.Rotated90DegreesRight().GetValue(), occupation] = RankAttack[square.GetValue(), occupation].Rotate90DegreesRight();

                    // The attack in diagonal is calculated based on the rank attack (by rotation)
                    DiagonalAttack[square.DiagonalRotated45DegreesLeft().GetValue(), occupation] = (RankAttack[square.GetValue(), occupation] & square.DiagonalRotatedMask()).RotateDiagonal45DegreesLeft();

                    // The attack in antidiagonals is calculated based on the rank attack (by rotating)
                    AntidiagonalAttack[square.AntidiagonalRotated45DegreesRight().GetValue(), occupation] = (RankAttack[square.GetValue(), occupation] & square.AntidiagonalRotatedMask()).RotateAntidiagonal45DegreesRight();
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

        public static ulong GetDiagonalAttack(Square square, ulong bitboard)
        {
            byte occupation = bitboard.RotateDiagonal45DegreesRight().RankOccupation(square.DiagonalRotated45DegreesRight().GetRank());

            return DiagonalAttack[square.GetValue(), occupation];
        }

        public static ulong GetAntidiagonalAttack(Square square, ulong bitboard)
        {
            byte occupation = bitboard.RotateAntidiagonal45DegreesLeft().RankOccupation(square.AntidiagonalRotated45DegreesLeft().GetRank());
            
            return AntidiagonalAttack[square.GetValue(), occupation];
        }
    }
}
