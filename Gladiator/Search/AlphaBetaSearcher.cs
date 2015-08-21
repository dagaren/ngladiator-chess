using Gladiator.Evaluation;
using Gladiator.Representation;
using Gladiator.Search.AlphaBeta;
using Gladiator.Utils;
using System;
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

        protected override Move SearchAction(IPosition<IBoard> position, SearchOptions searchOptions, CancellationToken cancellationToken)
        {
            IPrincipalVariationManager principalVariationManager = new PrincipalVariation();
            IMoveSorter moveSorter = new BasicMoveSorter();
            IMoveSorter mvvLvaSorter = new MvvLvaMoveSorter();

            var staticEvaluationStrategy = new AlphaBetaStaticEvaluationStrategy(this.staticEvaluator);
            var quiescenceStrategy = new AlphaBetaQuiescenceStrategy(staticEvaluationStrategy, mvvLvaSorter, this.commentWrite);
            var qprincipalVariationStrategy = new PrincipalVariationAlphaBetaStrategy(principalVariationManager, quiescenceStrategy);
            var qcancellationStrategy = new AlphaBetaCancellation(cancellationToken, qprincipalVariationStrategy);
            var qCounterStrategy = new AlphaBetaCounterStrategy(qcancellationStrategy);

            quiescenceStrategy.RecursiveStrategy = qCounterStrategy;

            var mainStrategy = new AlphaBetaMainStrategy(moveSorter, this.commentWrite);
            var principalVariationStrategy = new PrincipalVariationAlphaBetaStrategy(principalVariationManager, mainStrategy);
            var cancellationStrategy = new AlphaBetaCancellation(cancellationToken, principalVariationStrategy);
            var counterStrategy = new AlphaBetaCounterStrategy(cancellationStrategy);
            var finalPlyStrategy = new AlphaBetaFinalPlyStrategy(qCounterStrategy, counterStrategy);
            mainStrategy.RecursiveStrategy = finalPlyStrategy;

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
                int score = counterStrategy.AlphaBeta(initialStatus);
                int nodesPerSecond = (int)(counterStrategy.PositionsVisited + qCounterStrategy.PositionsVisited / stopwatch.Elapsed.TotalSeconds);

                commentWrite(string.Format("# Search time: {0:0.##} seconds", stopwatch.Elapsed.TotalSeconds));
                commentWrite(string.Format("# Nodes per second: {0}", nodesPerSecond));
                commentWrite(string.Format("# Result Score: {0}", score));
                commentWrite(string.Format("# Normal Nodes visited: {0}", counterStrategy.PositionsVisited));
                commentWrite(string.Format("# Quiescence nodes visited: {0}", qCounterStrategy.PositionsVisited));
                commentWrite(string.Format("# Total nodes visited: {0}", counterStrategy.PositionsVisited + qCounterStrategy.PositionsVisited));
                commentWrite(string.Format("# QSearch %: {0:0.##} ", 100 * qCounterStrategy.PositionsVisited / (qCounterStrategy.PositionsVisited + counterStrategy.PositionsVisited)));
            }
            catch (OperationCanceledException)
            {
                Move move = principalVariationManager.GetMoves().FirstOrDefault();
                if (move == null)
                {
                    move = position.GetMoves(MoveSearchType.LegalMoves).Random();
                }

                return move;
            }
            finally
            {
                stopwatch.Stop();
            }

            return initialStatus.BestMove;
        }
    }
}
