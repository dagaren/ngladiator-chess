using Gladiator.Evaluation;
using Gladiator.Representation;
using Gladiator.Search.AlphaBeta;
using Gladiator.Utils;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading;

namespace Gladiator.Search
{
    public class AlphaBetaSearcher : BaseSearcher
    {
        private Timer timer;

        private AlphaBetaStrategyBuilder strategyBuilder;

        public AlphaBetaSearcher(AlphaBetaStrategyBuilder strategyBuilder)
        {
            Check.ArgumentNotNull(strategyBuilder, "strategyBuilder");

            this.strategyBuilder = strategyBuilder;
        }

        protected override Move SearchAction(IPosition<IBoard> position, SearchOptions searchOptions, Action<PrincipalVariationChange> principalVariationChangeAction, CancellationTokenSource cancellationTokenSource)
        {
            if(searchOptions.SearchTime.Milliseconds > 0)
            {
                this.timer = new Timer((o) => { cancellationTokenSource.Cancel(); }, null, searchOptions.SearchTime, TimeSpan.FromMilliseconds(-1));
            }
            
            IPrincipalVariationManager principalVariationManager = new PrincipalVariation();

            this.strategyBuilder = this.strategyBuilder
                                            .WithCancellationToken(cancellationTokenSource.Token)
                                            .WithPrincipalVariationManager(principalVariationManager, principalVariationChangeAction);
            
            IAlphaBetaStrategy alphaBetaStrategy = this.strategyBuilder.Build();
            
            SearchStatus initialStatus = new SearchStatus()
            {
                Position = position,
                Alpha = AlphaBetaScore.InitialAlpha.Value(),
                Beta = AlphaBetaScore.InitialBeta.Value(),
                CurrentPly = 0,
                RemainingPlies = searchOptions.SearchDepth
            };

            var stopwatch = Stopwatch.StartNew();
            try
            {
                int score = alphaBetaStrategy.AlphaBeta(initialStatus);
            }
            catch (OperationCanceledException)
            {
                if(initialStatus.BestMove == null)
                {
                    initialStatus.BestMove = position.GetMoves(MoveSearchType.LegalMoves).Random();
                }
            }
            
            return initialStatus.BestMove;
        }
    }
}
