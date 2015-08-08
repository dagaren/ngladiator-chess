using System;

namespace Gladiator.Representation
{
    public static class RankExtensions
    {
        public static int GetValue(this Rank rank)
        {
            return (int)rank;
        }

        public static Rank Next(this Rank rank)
        {
            if(rank < Rank._8)
            {
                return rank + 1;
            }
            else
            {
                return Rank.None;
            }
        }

        public static Rank Previous(this Rank rank)
        {
            if (rank > Rank._1)
            {
                return rank - 1;
            }
            else
            {
                return Rank.None;
            }
        }
    }
}
