using Gladiator.Utils;
using System;
using System.Threading;

namespace Gladiator.Search.AlphaBeta
{
    class AlphaBetaCancellation : IAlphaBetaStrategy
    {
        private readonly CancellationToken cancellationToken;

        private readonly IAlphaBetaStrategy nextStrategy;

        public AlphaBetaCancellation(CancellationToken cancellationToken, IAlphaBetaStrategy nextStrategy)
        {
            Check.ArgumentNotNull(cancellationToken, "cancellationToken");
            Check.ArgumentNotNull(nextStrategy, "nextStrategy");

            this.cancellationToken = cancellationToken;
            this.nextStrategy = nextStrategy;
        }

        public int AlphaBeta(SearchStatus searchStatus)
        {
            if(this.cancellationToken.IsCancellationRequested)
            {
                this.cancellationToken.ThrowIfCancellationRequested();
            }
            
            return this.nextStrategy.AlphaBeta(searchStatus);
        }
    }
}
