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

        public AlphaBetaSearcher(IEvaluator staticEvaluator, Action<string> commentWrite)
        {
            Check.ArgumentNotNull(staticEvaluator, "staticEvaluator");
            Check.ArgumentNotNull(commentWrite, "commentWrite");

            this.staticEvaluator = staticEvaluator;
            this.commentWrite = commentWrite;
        }

        protected override Move SearchAction(IPosition<IBoard> position, SearchOptions searchOptions, Action<PrincipalVariationChange> principalVariationChangeAction, CancellationToken cancellationToken)
        {
            IPrincipalVariationManager principalVariationManager = new PrincipalVariation();
            INodeCounter nodeCounter = new NodeCounter();
            
            IMoveSorter moveSorter = new BasicMoveSorter();
            IMoveSorter mvvLvaSorter = new MvvLvaMoveSorter();

            var staticEvaluationStrategy = new AlphaBetaStaticEvaluationStrategy(this.staticEvaluator);
            var quiescenceStrategy = new AlphaBetaQuiescenceStrategy(staticEvaluationStrategy, mvvLvaSorter, this.commentWrite);
            var qprincipalVariationStrategy = new PrincipalVariationAlphaBetaStrategy(principalVariationManager, quiescenceStrategy);
            var qcancellationStrategy = new AlphaBetaCancellation(cancellationToken, qprincipalVariationStrategy);
            var qCounterStrategy = new AlphaBetaCounterStrategy(qcancellationStrategy, nodeCounter);

            quiescenceStrategy.RecursiveStrategy = qCounterStrategy;

            var mainStrategy = new AlphaBetaMainStrategy(moveSorter, this.commentWrite);
            var principalVariationStrategy = new PrincipalVariationAlphaBetaStrategy(principalVariationManager, mainStrategy);
            var cancellationStrategy = new AlphaBetaCancellation(cancellationToken, principalVariationStrategy);
            var counterStrategy = new AlphaBetaCounterStrategy(cancellationStrategy, nodeCounter);
            var finalPlyStrategy = new AlphaBetaFinalPlyStrategy(qCounterStrategy, counterStrategy);
            mainStrategy.RecursiveStrategy = finalPlyStrategy;

            var iterativeDeepeningStrategy = new AlphaBetaIterativeDeepeningStrategy(finalPlyStrategy);
            var entryStrategy = new AlphaBetaEntryStrategy(iterativeDeepeningStrategy, principalVariationManager, nodeCounter, principalVariationChangeAction);

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
                int score = entryStrategy.AlphaBeta(initialStatus);
            }
            catch (OperationCanceledException)
            {
                if(initialStatus.BestMove == null)
                {
                    initialStatus.BestMove = position.GetMoves(MoveSearchType.LegalMoves).Random();
                }
            }

            //Console.WriteLine("# " + nodeCounter.GetValue());
            
            return initialStatus.BestMove;
        }
    }
}
