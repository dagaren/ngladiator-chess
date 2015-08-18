using Gladiator.Utils;
using System;

namespace Gladiator.Search.AlphaBeta
{
    public class AlphaBetaPositionValidatedStrategy : IAlphaBetaStrategy
    {
        private IAlphaBetaStrategy nextStrategy;

        public AlphaBetaPositionValidatedStrategy(IAlphaBetaStrategy nextStrategy)
        {
            Check.ArgumentNotNull(nextStrategy, "nextStrategy");

            this.nextStrategy = nextStrategy;
        }

        public int AlphaBeta(SearchStatus searchStatus)
        {
            if(true) //todo: check position not valid
            {
                return AlphaBetaScore.InitialAlpha.Value();
            }

            return this.nextStrategy.AlphaBeta(searchStatus);
        }

    }
}
