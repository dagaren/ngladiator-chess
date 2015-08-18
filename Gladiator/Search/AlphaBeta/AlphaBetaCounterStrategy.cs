using Gladiator.Utils;
using System;

namespace Gladiator.Search.AlphaBeta
{
    class AlphaBetaCounterStrategy : IAlphaBetaStrategy
    {
        private readonly IAlphaBetaStrategy nextStrategy;

        public ulong PositionsVisited { get; private set; }

        public AlphaBetaCounterStrategy(IAlphaBetaStrategy nextStrategy)
        {
            Check.ArgumentNotNull(nextStrategy, "nextStrategy");

            this.nextStrategy = nextStrategy;
        }

        public int AlphaBeta(SearchStatus searchStatus)
        {
            this.PositionsVisited++;

            return this.nextStrategy.AlphaBeta(searchStatus);
        }
    }
}
