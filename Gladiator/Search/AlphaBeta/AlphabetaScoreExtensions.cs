using System;

namespace Gladiator.Search.AlphaBeta
{
    public static class AlphaBetaScoreExtensions
    {
        public static int Value(this AlphaBetaScore score)
        {
            return (int)score;
        }
    }
}
