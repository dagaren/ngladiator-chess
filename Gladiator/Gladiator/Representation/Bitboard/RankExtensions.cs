using Gladiator.Utils;
using System;

namespace Gladiator.Representation.Bitboard
{
    static class RankExtensions
    {
        public readonly static ulong[] Ranks = new ulong[8];

        static RankExtensions()
        {
            ulong rankBitboard = 0x00000000000000FFUL;
            foreach (Rank rank in EnumExtensions.GetValues<Rank>())
            {
                if (rank == Rank.None)
                {
                    continue;
                }

                Ranks[rank.GetValue()] = rankBitboard;
                rankBitboard = rankBitboard.ShiftRight(8);
            }
        }

        public static ulong GetBitboard(this Rank rank)
        {
            return Ranks[(int)rank];
        }
    }
}
