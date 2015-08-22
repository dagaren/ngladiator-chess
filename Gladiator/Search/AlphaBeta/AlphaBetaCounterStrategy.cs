using Gladiator.Utils;
using System;

namespace Gladiator.Search.AlphaBeta
{
    class AlphaBetaCounterStrategy : IAlphaBetaStrategy
    {
        private readonly IAlphaBetaStrategy nextStrategy;

        private readonly INodeCounter nodeCounter;

        public ulong PositionsVisited { get; private set; }

        public AlphaBetaCounterStrategy(IAlphaBetaStrategy nextStrategy, INodeCounter nodeCounter)
        {
            Check.ArgumentNotNull(nextStrategy, "nextStrategy");
            Check.ArgumentNotNull(nodeCounter, "nodeCounter");

            this.nextStrategy = nextStrategy;
            this.nodeCounter = nodeCounter;
        }

        public int AlphaBeta(SearchStatus searchStatus)
        {
            this.nodeCounter.Increment();

            return this.nextStrategy.AlphaBeta(searchStatus);
        }
    }
}
