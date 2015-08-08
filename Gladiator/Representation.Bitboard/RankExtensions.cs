using Gladiator.Utils;
using System;

namespace Gladiator.Representation.Bitboard
{
    public static class RankExtensions
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

        public static ulong OccupationBitboard(this Rank rank, byte occupation)
        {
            return ((ulong)occupation).ShiftRight((int)rank * 8);
        }
    }
}
