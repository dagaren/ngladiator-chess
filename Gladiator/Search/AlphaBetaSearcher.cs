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
        private Action<string> commentWrite;

        private IEvaluator staticEvaluator;

        private Timer timer;

        private AlphaBetaStrategyBuilder strategyBuilder;

        public AlphaBetaSearcher(IEvaluator staticEvaluator, Action<string> commentWrite)
        {
            Check.ArgumentNotNull(staticEvaluator, "staticEvaluator");
            Check.ArgumentNotNull(commentWrite, "commentWrite");

            this.staticEvaluator = staticEvaluator;
            this.commentWrite = commentWrite;
            this.strategyBuilder = new AlphaBetaStrategyBuilder()
                                            .WithAspirationWindow()
                                            .WithIterativeDeepening()
                                            .WithQuiescenceSearch()
                                            .WithTransposicionTable(new TranspositionTable(500000))
                                            .WithStaticEvaluator(this.staticEvaluator);
        }

        protected override Move SearchAction(IPosition<IBoard> position, SearchOptions searchOptions, Action<PrincipalVariationChange> principalVariationChangeAction, CancellationTokenSource cancellationTokenSource)
        {
            if(searchOptions.SearchTime.Milliseconds > 0)
            {
                this.timer = new Timer((o) => { cancellationTokenSource.Cancel(); }, null, searchOptions.SearchTime, TimeSpan.FromMilliseconds(-1));
            }
            
            IPrincipalVariationManager principalVariationManager = new PrincipalVariation();
            INodeCounter nodeCounter = new NodeCounter();

            this.strategyBuilder = this.strategyBuilder
                                            .WithCancellationToken(cancellationTokenSource.Token)
                                            .WithNodeCounter(nodeCounter)
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
            TimeSpan searchTime = stopwatch.Elapsed;
            stopwatch.Stop();
            double speed = nodeCounter.GetValue() / (searchTime.TotalSeconds * 1000);

            Console.WriteLine("# Nodes searched: {0}", nodeCounter.GetValue());
            Console.WriteLine("# Speed: {0:0.##} kN/s", speed);
            
            return initialStatus.BestMove;
        }
    }
}
