using Gladiator.Utils;
using System;
using System.Diagnostics;

namespace Gladiator.Search.AlphaBeta
{
    class AlphaBetaEntryStrategy : IAlphaBetaStrategy
    {
        private IAlphaBetaStrategy nextStrategy;

        private IPrincipalVariationManager principalVariation;

        private INodeCounter nodeCounter;

        private Stopwatch stopWatch;

        private SearchStatus currentSearchStatus;

        private Action<PrincipalVariationChange> principalVariationChangeAction;

        public AlphaBetaEntryStrategy(IAlphaBetaStrategy nextStrategy,
                                      IPrincipalVariationManager principalVariationManager,
                                      INodeCounter nodeCounter,
                                      Action<PrincipalVariationChange> principalVariationChangeAction)
        {
            Check.ArgumentNotNull(nextStrategy, "nextStrategy");
            Check.ArgumentNotNull(principalVariationManager, "principalVariationManager");
            Check.ArgumentNotNull(nodeCounter, "nodeCounter");
            Check.ArgumentNotNull(principalVariationChangeAction, "principalVariationChangeAction");

            this.nextStrategy = nextStrategy;
            this.principalVariation = principalVariationManager;
            this.nodeCounter = nodeCounter;
            this.principalVariationChangeAction = principalVariationChangeAction;
        }

        public int AlphaBeta(SearchStatus searchStatus)
        {
            this.stopWatch = Stopwatch.StartNew();
            this.currentSearchStatus = searchStatus;

            this.principalVariation.OnChanged += this.PrincipalVariationChanged;

            try
            {
                return this.nextStrategy.AlphaBeta(searchStatus);
            }
            finally
            {
                this.principalVariation.OnChanged -= this.PrincipalVariationChanged;
                this.stopWatch.Stop();
            }
        }

        private void PrincipalVariationChanged()
        {
            PrincipalVariationChange pvChange = new PrincipalVariationChange(
                    this.currentSearchStatus.RemainingPlies,
                    this.currentSearchStatus.Alpha,
                    stopWatch.Elapsed,
                    this.nodeCounter.GetValue(),
                    this.principalVariation.Moves);

            this.principalVariationChangeAction(pvChange);
        }
    }
}
