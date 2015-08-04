using Gladiator.Utils;
using System;

namespace Gladiator.Representation.Bitboard
{
    class PawnBitboards
    {
        public readonly static ulong[] WhiteAttackBitboards = new ulong[64];

        public readonly static ulong[] BlackAttackBitboards = new ulong[64];

        public readonly static ulong[] WhiteReachBitboards = new ulong[64];

        public readonly static ulong[] BlackReachBitboards = new ulong[64];

        static PawnBitboards()
        {
            foreach (Square square in EnumExtensions.GetValues<Square>())
            {
                if (square == Square.None)
                {
                    continue;
                }

                if (square.GetRank() == Rank._1)
                {
                    WhiteAttackBitboards[square.GetValue()] = BitboardExtensions.Empty;
                    WhiteReachBitboards[square.GetValue()] = BitboardExtensions.Empty;
                }
                else
                {
                    WhiteAttackBitboards[square.GetValue()] = BitboardExtensions.FromSquares(square.NextInDiagonal(), square.NextInAntiDiagonal());
                    WhiteReachBitboards[square.GetValue()] = square.NextInFile().GetBitboard();
                }

                if(square.GetRank() == Rank._2)
                {
                    WhiteReachBitboards[square.GetValue()] |= square.NextInFile().NextInFile().GetBitboard();
                }

                if(square.GetRank() == Rank._8)
                {
                    BlackAttackBitboards[square.GetValue()] = BitboardExtensions.Empty;
                    BlackReachBitboards[square.GetValue()] = BitboardExtensions.Empty;
                }
                else
                {
                    BlackAttackBitboards[square.GetValue()] = BitboardExtensions.FromSquares(square.PreviousInDiagonal(), square.PreviousInAntiDiagonal());
                    BlackReachBitboards[square.GetValue()] = square.PreviousInFile().GetBitboard();
                }

                if(square.GetRank() == Rank._7)
                {
                    BlackReachBitboards[square.GetValue()] |= square.PreviousInFile().PreviousInFile().GetBitboard();
                }
            }
        }
    }
}
