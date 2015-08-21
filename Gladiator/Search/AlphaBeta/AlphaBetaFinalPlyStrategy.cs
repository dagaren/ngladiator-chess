using Gladiator.Evaluation;
using Gladiator.Representation;
using Gladiator.Utils;
using System;

namespace Gladiator.Search.AlphaBeta
{
    public class AlphaBetaFinalPlyStrategy : IAlphaBetaStrategy
    {
        private IAlphaBetaStrategy finalPlyStrategy;

        private IAlphaBetaStrategy nextStrategy;

        public AlphaBetaFinalPlyStrategy(
            IAlphaBetaStrategy finalPlyStrategy,
            IAlphaBetaStrategy nextStrategy)
        {
            Check.ArgumentNotNull(finalPlyStrategy, "finalPlyStrategy");
            Check.ArgumentNotNull(nextStrategy, "nextStrategy");

            this.finalPlyStrategy = finalPlyStrategy;
            this.nextStrategy = nextStrategy;
        }

        public int AlphaBeta(SearchStatus searchStatus)
        {
            if(searchStatus.RemainingPlies == 0)
            {
                return this.finalPlyStrategy.AlphaBeta(searchStatus);
            }
            else
            {
                return this.nextStrategy.AlphaBeta(searchStatus);
            }
        }
    }
}
