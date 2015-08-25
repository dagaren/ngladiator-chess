using Gladiator.Utils;
using System;

namespace Gladiator.Search.AlphaBeta
{
    class AlphaBetaIterativeDeepeningStrategy : IAlphaBetaStrategy
    {
        private IAlphaBetaStrategy nextStrategy;

        public AlphaBetaIterativeDeepeningStrategy(IAlphaBetaStrategy nextStrategy)
        {
            Check.ArgumentNotNull(nextStrategy, "nextStrategy");

            this.nextStrategy = nextStrategy;
        }

        public int AlphaBeta(SearchStatus searchStatus)
        {
            int maxDepth = searchStatus.RemainingPlies;
            int initialAlpha = searchStatus.Alpha;
            int initialBeta = searchStatus.Beta;
            int score = 0;
            searchStatus.Score = 0;

            for(int i = 1; i <= maxDepth; i++)
            {
                searchStatus.RemainingPlies = i;
                searchStatus.Alpha = initialAlpha;
                searchStatus.Beta = initialBeta;
                
                score = this.nextStrategy.AlphaBeta(searchStatus);

                searchStatus.SuggestedMove = searchStatus.BestMove;
                searchStatus.Score = score;
            }

            return score;
        }
    }
}
