using Gladiator.Utils;
using System;

namespace Gladiator.Representation.Bitboard
{
    public class PawnBitboards
    {
        public readonly static ulong[,] AttackBitboards = new ulong[2, 64];

        public readonly static ulong[,] ReachBitboards = new ulong[2, 64];

        static PawnBitboards()
        {
            foreach (Square square in EnumExtensions.GetValues<Square>())
            {
                if (square == Square.None)
                {
                    continue;
                }

                AttackBitboards[Colour.White.Value(), square.GetValue()] = BitboardExtensions.FromSquares(square.NextInDiagonal(), square.NextInAntiDiagonal());
                ReachBitboards[Colour.White.Value(), square.GetValue()] = square.NextInFile().GetBitboard();

                AttackBitboards[Colour.Black.Value(), square.GetValue()] = BitboardExtensions.FromSquares(square.PreviousInDiagonal(), square.PreviousInAntiDiagonal());
                ReachBitboards[Colour.Black.Value(), square.GetValue()] = square.PreviousInFile().GetBitboard();
            }
        }
    }
}
